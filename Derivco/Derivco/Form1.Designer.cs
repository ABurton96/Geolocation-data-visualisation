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
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ActionSelection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(12, 317);
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
            // dateTimeFrom
            // 
            this.dateTimeFrom.Location = new System.Drawing.Point(12, 197);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(122, 20);
            this.dateTimeFrom.TabIndex = 17;
            this.dateTimeFrom.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Location = new System.Drawing.Point(12, 240);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(122, 20);
            this.dateTimeTo.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "From:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "To:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ActionSelection
            // 
            this.ActionSelection.FormattingEnabled = true;
            this.ActionSelection.ItemHeight = 13;
            this.ActionSelection.Location = new System.Drawing.Point(12, 118);
            this.ActionSelection.Name = "ActionSelection";
            this.ActionSelection.Size = new System.Drawing.Size(126, 21);
            this.ActionSelection.TabIndex = 21;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 583);
            this.Controls.Add(this.ActionSelection);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimeTo);
            this.Controls.Add(this.dateTimeFrom);
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
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ActionSelection;
        private System.Windows.Forms.Label label1;
    }
}

