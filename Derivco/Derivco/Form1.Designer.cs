namespace Derivco
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.confirmButton = new System.Windows.Forms.Button();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usenameLabel = new System.Windows.Forms.Label();
            this.userActionCheckBox = new System.Windows.Forms.CheckBox();
            this.loggedInCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loggedOutCheckBox = new System.Windows.Forms.CheckBox();
            this.watchedAdvertCheckBox = new System.Windows.Forms.CheckBox();
            this.playedGameCheckBox = new System.Windows.Forms.CheckBox();
            this.gameActionCheckBox = new System.Windows.Forms.CheckBox();
            this.purchasedItemCheckBox = new System.Windows.Forms.CheckBox();
            this.weekRadioButton = new System.Windows.Forms.RadioButton();
            this.monthRadioButton = new System.Windows.Forms.RadioButton();
            this.anyRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(8, 461);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(126, 59);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "Go!";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // gMap
            // 
            this.gMap.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(144, 0);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 20;
            this.gMap.MinZoom = 1;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(880, 578);
            this.gMap.TabIndex = 1;
            this.gMap.Zoom = 1D;
            this.gMap.Load += new System.EventHandler(this.gMap_Load);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(12, 44);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(126, 20);
            this.usernameTextBox.TabIndex = 2;
            // 
            // usenameLabel
            // 
            this.usenameLabel.AutoSize = true;
            this.usenameLabel.Location = new System.Drawing.Point(9, 28);
            this.usenameLabel.Name = "usenameLabel";
            this.usenameLabel.Size = new System.Drawing.Size(83, 13);
            this.usenameLabel.TabIndex = 3;
            this.usenameLabel.Text = "User ID Search:";
            this.usenameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userActionCheckBox
            // 
            this.userActionCheckBox.AutoSize = true;
            this.userActionCheckBox.Location = new System.Drawing.Point(12, 118);
            this.userActionCheckBox.Name = "userActionCheckBox";
            this.userActionCheckBox.Size = new System.Drawing.Size(81, 17);
            this.userActionCheckBox.TabIndex = 5;
            this.userActionCheckBox.Text = "User Action";
            this.userActionCheckBox.UseVisualStyleBackColor = true;
            this.userActionCheckBox.CheckedChanged += new System.EventHandler(this.userActionCheckBox_CheckedChanged);
            // 
            // loggedInCheckBox
            // 
            this.loggedInCheckBox.AutoSize = true;
            this.loggedInCheckBox.Enabled = false;
            this.loggedInCheckBox.Location = new System.Drawing.Point(34, 141);
            this.loggedInCheckBox.Name = "loggedInCheckBox";
            this.loggedInCheckBox.Size = new System.Drawing.Size(74, 17);
            this.loggedInCheckBox.TabIndex = 6;
            this.loggedInCheckBox.Text = "Logged In";
            this.loggedInCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Action:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loggedOutCheckBox
            // 
            this.loggedOutCheckBox.AutoSize = true;
            this.loggedOutCheckBox.Enabled = false;
            this.loggedOutCheckBox.Location = new System.Drawing.Point(34, 164);
            this.loggedOutCheckBox.Name = "loggedOutCheckBox";
            this.loggedOutCheckBox.Size = new System.Drawing.Size(82, 17);
            this.loggedOutCheckBox.TabIndex = 7;
            this.loggedOutCheckBox.Text = "Logged Out";
            this.loggedOutCheckBox.UseVisualStyleBackColor = true;
            // 
            // watchedAdvertCheckBox
            // 
            this.watchedAdvertCheckBox.AutoSize = true;
            this.watchedAdvertCheckBox.Enabled = false;
            this.watchedAdvertCheckBox.Location = new System.Drawing.Point(34, 232);
            this.watchedAdvertCheckBox.Name = "watchedAdvertCheckBox";
            this.watchedAdvertCheckBox.Size = new System.Drawing.Size(104, 17);
            this.watchedAdvertCheckBox.TabIndex = 10;
            this.watchedAdvertCheckBox.Text = "Watched Advert";
            this.watchedAdvertCheckBox.UseVisualStyleBackColor = true;
            // 
            // playedGameCheckBox
            // 
            this.playedGameCheckBox.AutoSize = true;
            this.playedGameCheckBox.Enabled = false;
            this.playedGameCheckBox.Location = new System.Drawing.Point(34, 209);
            this.playedGameCheckBox.Name = "playedGameCheckBox";
            this.playedGameCheckBox.Size = new System.Drawing.Size(89, 17);
            this.playedGameCheckBox.TabIndex = 9;
            this.playedGameCheckBox.Text = "Played Game";
            this.playedGameCheckBox.UseVisualStyleBackColor = true;
            // 
            // gameActionCheckBox
            // 
            this.gameActionCheckBox.AutoSize = true;
            this.gameActionCheckBox.Location = new System.Drawing.Point(12, 186);
            this.gameActionCheckBox.Name = "gameActionCheckBox";
            this.gameActionCheckBox.Size = new System.Drawing.Size(87, 17);
            this.gameActionCheckBox.TabIndex = 8;
            this.gameActionCheckBox.Text = "Game Action";
            this.gameActionCheckBox.UseVisualStyleBackColor = true;
            this.gameActionCheckBox.CheckedChanged += new System.EventHandler(this.gameActionCheckBox_CheckedChanged);
            // 
            // purchasedItemCheckBox
            // 
            this.purchasedItemCheckBox.AutoSize = true;
            this.purchasedItemCheckBox.Enabled = false;
            this.purchasedItemCheckBox.Location = new System.Drawing.Point(34, 255);
            this.purchasedItemCheckBox.Name = "purchasedItemCheckBox";
            this.purchasedItemCheckBox.Size = new System.Drawing.Size(100, 17);
            this.purchasedItemCheckBox.TabIndex = 11;
            this.purchasedItemCheckBox.Text = "Purchased Item";
            this.purchasedItemCheckBox.UseVisualStyleBackColor = true;
            // 
            // weekRadioButton
            // 
            this.weekRadioButton.AutoSize = true;
            this.weekRadioButton.Location = new System.Drawing.Point(33, 356);
            this.weekRadioButton.Name = "weekRadioButton";
            this.weekRadioButton.Size = new System.Drawing.Size(54, 17);
            this.weekRadioButton.TabIndex = 13;
            this.weekRadioButton.Text = "Week";
            this.weekRadioButton.UseVisualStyleBackColor = true;
            // 
            // monthRadioButton
            // 
            this.monthRadioButton.AutoSize = true;
            this.monthRadioButton.Location = new System.Drawing.Point(33, 333);
            this.monthRadioButton.Name = "monthRadioButton";
            this.monthRadioButton.Size = new System.Drawing.Size(55, 17);
            this.monthRadioButton.TabIndex = 14;
            this.monthRadioButton.Text = "Month";
            this.monthRadioButton.UseVisualStyleBackColor = true;
            // 
            // anyRadioButton
            // 
            this.anyRadioButton.AutoSize = true;
            this.anyRadioButton.Checked = true;
            this.anyRadioButton.Location = new System.Drawing.Point(34, 310);
            this.anyRadioButton.Name = "anyRadioButton";
            this.anyRadioButton.Size = new System.Drawing.Size(43, 17);
            this.anyRadioButton.TabIndex = 15;
            this.anyRadioButton.TabStop = true;
            this.anyRadioButton.Text = "Any";
            this.anyRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Time Span:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 392);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 20);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(12, 435);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(122, 20);
            this.dateTimePicker2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "From:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "To:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 583);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.anyRadioButton);
            this.Controls.Add(this.monthRadioButton);
            this.Controls.Add(this.weekRadioButton);
            this.Controls.Add(this.purchasedItemCheckBox);
            this.Controls.Add(this.watchedAdvertCheckBox);
            this.Controls.Add(this.playedGameCheckBox);
            this.Controls.Add(this.gameActionCheckBox);
            this.Controls.Add(this.loggedOutCheckBox);
            this.Controls.Add(this.loggedInCheckBox);
            this.Controls.Add(this.userActionCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usenameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.gMap);
            this.Controls.Add(this.confirmButton);
            this.Name = "Form1";
            this.Text = "WebPage";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usenameLabel;
        private System.Windows.Forms.CheckBox userActionCheckBox;
        private System.Windows.Forms.CheckBox loggedInCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox loggedOutCheckBox;
        private System.Windows.Forms.CheckBox watchedAdvertCheckBox;
        private System.Windows.Forms.CheckBox playedGameCheckBox;
        private System.Windows.Forms.CheckBox gameActionCheckBox;
        private System.Windows.Forms.CheckBox purchasedItemCheckBox;
        private System.Windows.Forms.RadioButton weekRadioButton;
        private System.Windows.Forms.RadioButton monthRadioButton;
        private System.Windows.Forms.RadioButton anyRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

