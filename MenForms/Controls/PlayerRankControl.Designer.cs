namespace MenForms.Controls
{
    partial class PlayerRankControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerRankControl));
            pbPlayerImage = new PictureBox();
            lblName = new Label();
            lblPlayerName = new Label();
            lblPlayerNumberOfOccurances = new Label();
            lblNumberOfOccurances = new Label();
            lblPlayerNumberOfGoals = new Label();
            lblNumberOfGoals = new Label();
            lblPlayerfNumberOfYellowCards = new Label();
            lblNumberOfYellowCards = new Label();
            lblPlayerRank = new Label();
            lblRank = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).BeginInit();
            SuspendLayout();
            // 
            // pbPlayerImage
            // 
            resources.ApplyResources(pbPlayerImage, "pbPlayerImage");
            pbPlayerImage.Name = "pbPlayerImage";
            pbPlayerImage.TabStop = false;
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.Name = "lblName";
            // 
            // lblPlayerName
            // 
            resources.ApplyResources(lblPlayerName, "lblPlayerName");
            lblPlayerName.Name = "lblPlayerName";
            // 
            // lblPlayerNumberOfOccurances
            // 
            resources.ApplyResources(lblPlayerNumberOfOccurances, "lblPlayerNumberOfOccurances");
            lblPlayerNumberOfOccurances.Name = "lblPlayerNumberOfOccurances";
            // 
            // lblNumberOfOccurances
            // 
            resources.ApplyResources(lblNumberOfOccurances, "lblNumberOfOccurances");
            lblNumberOfOccurances.Name = "lblNumberOfOccurances";
            // 
            // lblPlayerNumberOfGoals
            // 
            resources.ApplyResources(lblPlayerNumberOfGoals, "lblPlayerNumberOfGoals");
            lblPlayerNumberOfGoals.Name = "lblPlayerNumberOfGoals";
            // 
            // lblNumberOfGoals
            // 
            resources.ApplyResources(lblNumberOfGoals, "lblNumberOfGoals");
            lblNumberOfGoals.Name = "lblNumberOfGoals";
            // 
            // lblPlayerfNumberOfYellowCards
            // 
            resources.ApplyResources(lblPlayerfNumberOfYellowCards, "lblPlayerfNumberOfYellowCards");
            lblPlayerfNumberOfYellowCards.Name = "lblPlayerfNumberOfYellowCards";
            // 
            // lblNumberOfYellowCards
            // 
            resources.ApplyResources(lblNumberOfYellowCards, "lblNumberOfYellowCards");
            lblNumberOfYellowCards.Name = "lblNumberOfYellowCards";
            // 
            // lblPlayerRank
            // 
            resources.ApplyResources(lblPlayerRank, "lblPlayerRank");
            lblPlayerRank.Name = "lblPlayerRank";
            // 
            // lblRank
            // 
            resources.ApplyResources(lblRank, "lblRank");
            lblRank.Name = "lblRank";
            // 
            // PlayerRankControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPlayerRank);
            Controls.Add(lblRank);
            Controls.Add(lblPlayerfNumberOfYellowCards);
            Controls.Add(lblNumberOfYellowCards);
            Controls.Add(lblPlayerNumberOfGoals);
            Controls.Add(lblNumberOfGoals);
            Controls.Add(lblPlayerNumberOfOccurances);
            Controls.Add(lblNumberOfOccurances);
            Controls.Add(lblPlayerName);
            Controls.Add(lblName);
            Controls.Add(pbPlayerImage);
            Name = "PlayerRankControl";
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbPlayerImage;
        private Label lblName;
        private Label lblPlayerName;
        private Label lblPlayerNumberOfOccurances;
        private Label lblNumberOfOccurances;
        private Label lblPlayerNumberOfGoals;
        private Label lblNumberOfGoals;
        private Label lblPlayerfNumberOfYellowCards;
        private Label lblNumberOfYellowCards;
        private Label lblPlayerRank;
        private Label lblRank;

        public string lblNameTxt
        {
            get { return lblPlayerName.Text; }
            set { lblPlayerName.Text = value; }
        }

        public int lblNumberOfOccurancesTxt
        {
            get { return int.Parse(lblPlayerNumberOfOccurances.ToString().Trim()); }
            set { lblPlayerNumberOfOccurances.Text = value.ToString(); }
        }

        public int lblPlayerNumberOfGoalsTxt
        {
            get { return int.Parse(lblPlayerNumberOfGoals.ToString().Trim()); }
            set { lblPlayerNumberOfGoals.Text = value.ToString(); }
        }
        public int lblPlayerfNumberOfYellowCardsTxt
        {
            get { return int.Parse(lblPlayerfNumberOfYellowCards.ToString().Trim()); }
            set { lblPlayerfNumberOfYellowCards.Text = value.ToString(); }
        }
        public int lblPlayerRankTxt
        {
            get { return int.Parse(lblPlayerRank.ToString().Trim()); }
            set { lblPlayerRank.Text = value.ToString(); }
        }

        public Image PlayerImage
        {
            get { return pbPlayerImage.Image; }
            set { pbPlayerImage.Image = value; }
        }
    }
}
