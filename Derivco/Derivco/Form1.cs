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

        public class AllEvents
        {
            public string username;
            public string action;
            public double latitude;
            public double longitude;
            public int clutter;
            public DateTime date;
        }

        enum userAction { LoggedIn, LoggedOut };
        enum gameAction { PlayedGame, WatchedAdvert, PurchasedItem };

        String[] userAction2 = { "LoggedIn", "LoggedOut" };
        String[] gameAction2 = { "PlayedGame", "WatchedAdvert", "PurchasedItem" };

        List<AllEvents> allEventsList = new List<AllEvents>();
        SQLiteConnection dbConnect;

        DateTime currentDate = DateTime.Now;

        Random randomDouble = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();

            if (!File.Exists("Events.sqlite"))
            // if (true)
            {
                SQLiteConnection.CreateFile("Events.sqlite");

                dbConnect = new SQLiteConnection("Data Source=Events.sqlite;Version=3;");
                dbConnect.Open();

                SQLiteCommand commandLoggedIn = new SQLiteCommand("create table LoggedIn (user varchar(10), action varchar(20), latitude float, longitude float, date datetime)", dbConnect);
                commandLoggedIn.ExecuteNonQuery();

                SQLiteCommand commandLoggedOut = new SQLiteCommand("create table LoggedOut (user varchar(10), action varchar(20), latitude float, longitude float, date datetime)", dbConnect);
                commandLoggedOut.ExecuteNonQuery();

                SQLiteCommand commandPlayedGame = new SQLiteCommand("create table PlayedGame (user varchar(10), action varchar(20), latitude float, longitude float, date datetime)", dbConnect);
                commandPlayedGame.ExecuteNonQuery();

                SQLiteCommand commandWatchedAdvert = new SQLiteCommand("create table WatchedAdvert (user varchar(10), action varchar(20), latitude float, longitude float, date datetime)", dbConnect);
                commandWatchedAdvert.ExecuteNonQuery();

                SQLiteCommand commandPurchasedItem = new SQLiteCommand("create table PurchasedItem (user varchar(10), action varchar(20), latitude float, longitude float, date datetime)", dbConnect);
                commandPurchasedItem.ExecuteNonQuery();

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
                    string eventString = "insert into " + allEvents.action;
                    eventString += "(user, action, latitude, longitude, date) values(@username, @act, @lat, @long, @date)";
                    //SQLiteCommand eventInsert = new SQLiteCommand("insert into event (user, action, latitude, longitude) values (@username, @act, @lat, @long);", dbConnect);

                    SQLiteCommand eventInsert = new SQLiteCommand(eventString, dbConnect);

                    eventInsert.Parameters.AddWithValue("@username", allEvents.username);
                    eventInsert.Parameters.AddWithValue("@act", allEvents.action.ToString());
                    eventInsert.Parameters.AddWithValue("@lat", allEvents.latitude);
                    eventInsert.Parameters.AddWithValue("@long", allEvents.longitude);
                    eventInsert.Parameters.AddWithValue("@date", allEvents.date);

                    eventInsert.ExecuteNonQuery();

                    //Console.WriteLine(i.ToString());
                    //allEventsList.Add(allEvents);
                }
            }
            else
            {
                dbConnect = new SQLiteConnection("Data Source=Events.sqlite;Version=3;");
                dbConnect.Open();
            }
        }

        //Returns a random double
        public double GetRandomNumber(double min, double max)
        {
            return randomDouble.NextDouble() * (max - min) + min;
        }

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

        public String GetAction()
        {
            Random random = new Random();
            //Returns a randomly selects either a random userAction or gameAction.
            int ran = randomDouble.Next(2);

            if (ran == 0)
            {
                ran = randomDouble.Next(userAction2.Length);

                switch (ran)
                {
                    case 0:
                        return userAction2[0];
                    case 1:
                        return userAction2[1];
                }
            }
            else
            {
                ran = randomDouble.Next(gameAction2.Length);

                switch (ran)
                {
                    case 0:
                        return gameAction2[0];
                    case 1:
                        return gameAction2[1];
                    case 2:
                        return gameAction2[2];
                }
            }
            return String.Empty;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

            GMapOverlay markers = new GMapOverlay("Markers");
            //Clears current overlays 
            gMap.Overlays.Clear();

            #region LoggedIn
            if (loggedInCheckBox.Checked == true)
            {
                bool userCheck = false;

                if (usernameTextBox.Text != String.Empty)
                {
                    userCheck = true;
                }

                string query = "select * from loggedIn ";

                if (userCheck)
                {
                    query += "where user = " + usernameTextBox.Text + " ;";
                }
                else
                {
                    query += ";";
                }

                SQLiteCommand command = new SQLiteCommand(query, dbConnect);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GMarkerGoogleType markerColour = GMarkerGoogleType.lightblue_pushpin;

                    TimeSpan diff;

                    diff = currentDate - DateTime.Parse(reader["date"].ToString());

                    if (InTime(diff))
                    {
                        double latitude = double.Parse(reader["latitude"].ToString());
                        double longitude = double.Parse(reader["longitude"].ToString());

                        GMapMarker marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerColour);
                        markers.Markers.Add(marker);
                    }
                }
            }

            #endregion

            #region LoggedOut
            if (loggedOutCheckBox.Checked == true)
            {
                bool userCheck = false;

                if (usernameTextBox.Text != String.Empty)
                {
                    userCheck = true;
                }

                string query = "select * from loggedOut ";

                if (userCheck)
                {
                    query += "where user = " + usernameTextBox.Text + " ;";
                }
                else
                {
                    query += ";";
                }

                SQLiteCommand command = new SQLiteCommand(query, dbConnect);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GMarkerGoogleType markerColour = GMarkerGoogleType.purple_pushpin;

                    TimeSpan diff;

                    diff = currentDate - DateTime.Parse(reader["date"].ToString());

                    if (InTime(diff))
                    {
                        double latitude = double.Parse(reader["latitude"].ToString());
                        double longitude = double.Parse(reader["longitude"].ToString());

                        GMapMarker marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerColour);
                        markers.Markers.Add(marker);
                    }
                }
            }

            #endregion

            #region PlayedGame
            if (playedGameCheckBox.Checked == true)
            {
                bool userCheck = false;

                if (usernameTextBox.Text != String.Empty)
                {
                    userCheck = true;
                }

                string query = "select * from playedGame ";

                if (userCheck)
                {
                    query += "where user = " + usernameTextBox.Text + " ;";
                }
                else
                {
                    query += ";";
                }

                SQLiteCommand command = new SQLiteCommand(query, dbConnect);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GMarkerGoogleType markerColour = GMarkerGoogleType.green_pushpin;

                    TimeSpan diff;

                    diff = currentDate - DateTime.Parse(reader["date"].ToString());

                    if (InTime(diff))
                    {
                        double latitude = double.Parse(reader["latitude"].ToString());
                        double longitude = double.Parse(reader["longitude"].ToString());

                        GMapMarker marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerColour);
                        markers.Markers.Add(marker);
                    }
                }
            }

            #endregion

            #region WatchedAdvert
            if (watchedAdvertCheckBox.Checked == true)
            {
                bool userCheck = false;

                if (usernameTextBox.Text != String.Empty)
                {
                    userCheck = true;
                }

                string query = "select * from watchedAdvert ";

                if (userCheck)
                {
                    query += "where user = " + usernameTextBox.Text + " ;";
                }
                else
                {
                    query += ";";
                }

                SQLiteCommand command = new SQLiteCommand(query, dbConnect);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GMarkerGoogleType markerColour = GMarkerGoogleType.pink_pushpin;

                    TimeSpan diff;

                    diff = currentDate - DateTime.Parse(reader["date"].ToString());

                    if (InTime(diff))
                    {
                        double latitude = double.Parse(reader["latitude"].ToString());
                        double longitude = double.Parse(reader["longitude"].ToString());

                        GMapMarker marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerColour);
                        markers.Markers.Add(marker);
                    }
                }
            }

            #endregion

            #region LoggedIn
            if (purchasedItemCheckBox.Checked == true)
            {
                bool userCheck = false;

                if (usernameTextBox.Text != String.Empty)
                {
                    userCheck = true;
                }

                string query = "select * from purchasedItem ";

                if (userCheck)
                {
                    query += "where user = " + usernameTextBox.Text + " ;";
                }
                else
                {
                    query += ";";
                }

                SQLiteCommand command = new SQLiteCommand(query, dbConnect);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GMarkerGoogleType markerColour = GMarkerGoogleType.yellow_pushpin;

                    TimeSpan diff;

                    diff = currentDate - DateTime.Parse(reader["date"].ToString());

                    if (InTime(diff))
                    {
                        double latitude = double.Parse(reader["latitude"].ToString());
                        double longitude = double.Parse(reader["longitude"].ToString());

                        GMapMarker marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), markerColour);
                        markers.Markers.Add(marker);
                    }
                }
            }

            #endregion
            
            //Draw overlay on screen
            gMap.Overlays.Add(markers);

            double zoomLevel = gMap.Zoom;

            //Only seems to refresh once you zoom in/out. gMap.Refresh() doesn't help
            gMap.Zoom = 0;
            gMap.Zoom = zoomLevel;
        }

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
