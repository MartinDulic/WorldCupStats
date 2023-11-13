namespace MenForms.Controls
{
    partial class MatchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchControl));
            lblHomeCountry = new Label();
            lblVs = new Label();
            lblAwayCountry = new Label();
            lblVenue = new Label();
            lblMatchVenue = new Label();
            lblAttendance = new Label();
            lblMatchAtendance = new Label();
            SuspendLayout();
            // 
            // lblHomeCountry
            // 
            resources.ApplyResources(lblHomeCountry, "lblHomeCountry");
            lblHomeCountry.Name = "lblHomeCountry";
            // 
            // lblVs
            // 
            resources.ApplyResources(lblVs, "lblVs");
            lblVs.Name = "lblVs";
            // 
            // lblAwayCountry
            // 
            resources.ApplyResources(lblAwayCountry, "lblAwayCountry");
            lblAwayCountry.Name = "lblAwayCountry";
            // 
            // lblVenue
            // 
            resources.ApplyResources(lblVenue, "lblVenue");
            lblVenue.Name = "lblVenue";
            // 
            // lblMatchVenue
            // 
            resources.ApplyResources(lblMatchVenue, "lblMatchVenue");
            lblMatchVenue.Name = "lblMatchVenue";
            // 
            // lblAttendance
            // 
            resources.ApplyResources(lblAttendance, "lblAttendance");
            lblAttendance.Name = "lblAttendance";
            // 
            // lblMatchAtendance
            // 
            resources.ApplyResources(lblMatchAtendance, "lblMatchAtendance");
            lblMatchAtendance.Name = "lblMatchAtendance";
            // 
            // MatchControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblMatchAtendance);
            Controls.Add(lblAttendance);
            Controls.Add(lblMatchVenue);
            Controls.Add(lblVenue);
            Controls.Add(lblAwayCountry);
            Controls.Add(lblVs);
            Controls.Add(lblHomeCountry);
            Name = "MatchControl";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHomeCountry;
        private Label lblVs;
        private Label lblAwayCountry;
        private Label lblVenue;
        private Label lblMatchVenue;
        private Label lblAttendance;
        private Label lblMatchAtendance;

        public string AwayCountry
        {
            get => lblAwayCountry.Text;
            set => lblAwayCountry.Text = value;
        }
        public string HomeCountry
        {
            get => lblHomeCountry.Text;
            set => lblHomeCountry.Text = value;
        }
        public string Venue
        {
            get => lblMatchVenue.Text;
            set => lblMatchVenue.Text = value;
        }

        public int Attendance
        {
            get => int.Parse(lblMatchAtendance.Text);
            set => lblMatchAtendance.Text = value.ToString();
        }

    }
}
