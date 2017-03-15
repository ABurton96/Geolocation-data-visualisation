using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace Derivco
{
    public partial class Form1 : Form
    {

        public enum Event {
            LoggedIn = 0,
            LoggedOut,
            PlayedGame,
            WatchedAdvert,
            PurchasedItem,
            All
        }

        public class AllEvents
        {
            public string username;
            public Event action;
            public double latitude;
            public double longitude;
            public DateTime date;
        }

        public class Markers
        {
            public double latitude;
            public double longitude;
            public GMarkerGoogleType markerColour2;
            public int clutter;
        }

        List<AllEvents> allEventsList = new List<AllEvents>();
        List<Markers> markersToAdd = new List<Markers>();
        SQLiteConnection dbConnect;

        DateTime currentDate = DateTime.Now;

        Random randomDouble = new Random();

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Random random = new Random();

            //Checks if the event database has already been created
            if (!File.Exists("Events.sqlite"))
            {
                //If its not created then create the database and fill it with tables
                SQLiteConnection.CreateFile("Events.sqlite");

                dbConnect = new SQLiteConnection("Data Source=Events.sqlite;Version=3;");
                dbConnect.Open();

                SQLiteCommand commandLoggedIn = new SQLiteCommand("create table Events (user int, action varchar(10), latitude float, longitude float, date datetime)", dbConnect);
                commandLoggedIn.ExecuteNonQuery();

                //Runs loop 10,000 times to fill list with random events, locations and different users
                for (int i = 0; i < 10000; i++)
                {
                    AllEvents allEvents = new AllEvents();
                    allEvents.username = random.Next(100).ToString();
                    int actionNum = random.Next(5);

                    allEvents.action = GetAction();

                    allEvents.latitude = GetRandomNumber(-90, 90);
                    allEvents.longitude = GetRandomNumber(-180, 180);

                    allEvents.date = GetRandomDate();

                    //Inserts data into SQL database
                    string eventString = "";
                    eventString += "insert into Events (user, action, latitude, longitude, date) values(@username, @act, @lat, @long, @date)";

                    SQLiteCommand eventInsert = new SQLiteCommand(eventString, dbConnect);

                    eventInsert.Parameters.AddWithValue("@username", allEvents.username);
                    eventInsert.Parameters.AddWithValue("@act", allEvents.action.ToString());
                    eventInsert.Parameters.AddWithValue("@lat", allEvents.latitude);
                    eventInsert.Parameters.AddWithValue("@long", allEvents.longitude);
                    eventInsert.Parameters.AddWithValue("@date", allEvents.date);

                    eventInsert.ExecuteNonQuery();
                }
            }
            else
            {
                //If database has been created then load it
                dbConnect = new SQLiteConnection("Data Source=Events.sqlite;Version=3;");
                dbConnect.Open();
            }
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            confirmButton_Click(sender, e);
        }

        //Returns a random double
        public double GetRandomNumber(double min, double max)
        {
            return randomDouble.NextDouble() * (max - min) + min;
        }

        //Gets a random date between now and start of previous month
        public DateTime GetRandomDate()
        {
            DateTime date;
            DateTime minDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime month = minDate.AddMonths(-1);

            date = month;

            int range = (currentDate - month).Days;

            date = date.AddDays(randomDouble.Next(range));
            return date;
        }

        public Event GetAction()
        {
            Random random = new Random();
            //Returns a randomly selects either a random userAction or gameAction.
            int ran = randomDouble.Next((int)Event.All);

            return (Event)ran;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            GMapOverlay markers = new GMapOverlay("Markers");
            //Clears current overlays 
            gMap.Overlays.Clear();
            markersToAdd.Clear();

            string queryExample = "SELECT * FROM Events";
            List<string> options = new List<string>();
            string quote = "\"";

            //Checks if checkbox is ticked
            if (loggedInCheckBox.Checked == true)
            {
                options.Add("action = " + quote + Event.LoggedIn.ToString() + quote);
            }

            if (loggedOutCheckBox.Checked == true)
            {
                options.Add("action = " + quote + Event.LoggedOut.ToString() + quote);
            }

            if (playedGameCheckBox.Checked == true)
            {
                options.Add("action = " + quote + Event.PlayedGame.ToString() + quote);
            }
            
            if (watchedAdvertCheckBox.Checked == true)
            {
                options.Add("action = " + quote + Event.WatchedAdvert.ToString() + quote);
            }

            if (purchasedItemCheckBox.Checked == true)
            {
                options.Add("action = " + quote + Event.PurchasedItem.ToString() + quote);
            }

            bool addedOptions = false;

            if (options.Count > 0) {

                string queryAddon = "(";

                for (int i = 0; i < options.Count; i++) {
                    string item = options[i];
                    queryAddon += item;

                    if ( i != options.Count - 1)
                    {
                        queryAddon += " OR ";
                    }
                }

                queryAddon += ")";

                queryExample += " WHERE " + queryAddon;

                addedOptions = true;
            }

            bool addedName = false;

            // check if user specified:
            if ( usernameTextBox.Text != string.Empty)
            {
                if (addedOptions)
                    queryExample += " AND ";
                else
                    queryExample += " WHERE ";

                queryExample += "user = " + usernameTextBox.Text;
                addedName = true;
            }

            queryExample += ";";

            if (addedOptions && addedName || addedOptions)
            {
                //Sends query to databse
                SQLiteCommand command = new SQLiteCommand(queryExample, dbConnect);
                SQLiteDataReader reader = command.ExecuteReader();

                //Waits while database is read. Checking each return to see if it matches the search criteria
                while (reader.Read())
                {
                    GMarkerGoogleType markerColour = GetColour(reader["action"].ToString());

                    TimeSpan diff;

                    diff = currentDate - DateTime.Parse(reader["date"].ToString());

                    if (InTime(diff))
                    {
                        double latitude = double.Parse(reader["latitude"].ToString());
                        double longitude = double.Parse(reader["longitude"].ToString());

                        Markers currentMarker = new Markers();

                        currentMarker.latitude = latitude;
                        currentMarker.longitude = longitude;
                        currentMarker.markerColour2 = markerColour;

                        Tuple<bool, int> check = PlaceMarker(currentMarker.latitude, currentMarker.longitude);

                        if (check.Item1)
                        {
                            markersToAdd.Add(currentMarker);
                        }
                        else
                        {
                            currentMarker.clutter = check.Item2;
                            markersToAdd.Add(currentMarker);
                        }
                    }
                }
            }

            //Takes all returned data (That was applicable to the search criteria) and checks for clutter
            for (int i = 0; i < markersToAdd.Count - 1; i ++)
            {
                if(markersToAdd[i].clutter > 0)
                {
                    markersToAdd[i].markerColour2 = GMarkerGoogleType.orange_dot;
                }
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(markersToAdd[i].latitude, markersToAdd[i].longitude), markersToAdd[i].markerColour2);
                if(markersToAdd[i].clutter > 0)
                    marker.ToolTipText = "Amount of points: " + (markersToAdd[i].clutter + 1).ToString();
                markers.Markers.Add(marker);
            }

            //Draw overlay on screen
            gMap.Overlays.Add(markers);

            double zoomLevel = gMap.Zoom;

            //Only seems to refresh once you zoom in/out. gMap.Refresh() doesn't help
            gMap.Zoom = 0;
            gMap.Zoom = zoomLevel;
        }


        //Returns marker colour
        public GMarkerGoogleType GetColour(string actionName)
        {
            switch(actionName)
            {
                case "LoggedIn": return GMarkerGoogleType.lightblue_pushpin;
                case "LoggedOut": return GMarkerGoogleType.green_pushpin;
                case "PlayedGame": return GMarkerGoogleType.red_pushpin;
                case "WatchedAdvert": return GMarkerGoogleType.yellow_pushpin;
                case "PurchasedItem": return GMarkerGoogleType.blue_pushpin;
            }
            return GMarkerGoogleType.orange;
        }

        public Tuple<bool, int> PlaceMarker(double lat, double lon)
        {

            int clutterAmount;

            //Checks current map zoom
            if(gMap.Zoom >= 5)
            {
                clutterAmount = 0;
            }
            else if (gMap.Zoom >= 3)
            {
                clutterAmount = 3;
            }
            else if (gMap.Zoom >= 1)
            {
                clutterAmount = 8;
            }
            else
            {
                clutterAmount = 12;
            }

            //For each point already on the map check it against the point that is about to be added
            for (int j = 0; j < markersToAdd.Count - 1; j++)
            {
                int clutter = markersToAdd[j].clutter;

                if (markersToAdd[j].longitude >= lon - clutterAmount && markersToAdd[j].longitude <= lon + clutterAmount && markersToAdd[j].latitude >= lat - clutterAmount && markersToAdd[j].latitude <= lat + clutterAmount)
                {
                    markersToAdd.Remove(markersToAdd[j]);
                    return Tuple.Create(false, clutter + 1);
                }
            }
            return Tuple.Create(false, 0);
        }

        //Check to see if the time of the event happened within the search time
        public bool InTime(TimeSpan time)
        {
            bool addMarker = false;

            if (anyRadioButton.Checked)
            {
                addMarker = true;
            }
            else if (monthRadioButton.Checked)
            {
                if (time.TotalDays <= 30)
                {
                    addMarker = true;
                }
            }
            else if (weekRadioButton.Checked)
            {
                if (time.TotalDays <= 7)
                {
                    addMarker = true;
                }
            }

            return addMarker;
        }

        //Once map is loaded set the map provider
        private void gMap_Load(object sender, EventArgs e)
        {
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.ShowCenter = false;
            gMap.SetPositionByKeywords("University Of Suffolk, Ipswich");
        }

        //If gameAction check box is/isn't checks set other check boxs acordingly 
        private void gameActionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (gameActionCheckBox.Checked == true)
            {
                playedGameCheckBox.Enabled = true;
                watchedAdvertCheckBox.Enabled = true;
                purchasedItemCheckBox.Enabled = true;
                playedGameCheckBox.Checked = true;
                watchedAdvertCheckBox.Checked = true;
                purchasedItemCheckBox.Checked = true;
            }
            else
            {
                playedGameCheckBox.Checked = false;
                watchedAdvertCheckBox.Checked = false;
                purchasedItemCheckBox.Checked = false;
                playedGameCheckBox.Enabled = false;
                watchedAdvertCheckBox.Enabled = false;
                purchasedItemCheckBox.Enabled = false;
            }
        }

        //If userAction check box is/isn't checks set other check boxs acordingly 
        private void userActionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (userActionCheckBox.Checked == true)
            {
                loggedInCheckBox.Enabled = true;
                loggedOutCheckBox.Enabled = true;
                loggedInCheckBox.Checked = true;
                loggedOutCheckBox.Checked = true;
            }
            else
            {
                loggedInCheckBox.Checked = false;
                loggedOutCheckBox.Checked = false;
                loggedInCheckBox.Enabled = false;
                loggedOutCheckBox.Enabled = false;
            }
        }
    }
}
