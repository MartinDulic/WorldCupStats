namespace MenForms
{
    partial class RankForm
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
            lblPlayersGoalsScored = new Label();
            flpGoalsScored = new FlowLayoutPanel();
            lblRankingsBy = new Label();
            flpYellowCards = new FlowLayoutPanel();
            lblYellowCards = new Label();
            flpAttendance = new FlowLayoutPanel();
            lblVenuesByAttendance = new Label();
            lblLoading = new Label();
            SuspendLayout();
            // 
            // lblPlayersGoalsScored
            // 
            lblPlayersGoalsScored.AutoSize = true;
            lblPlayersGoalsScored.Font = new Font("Sitka Banner", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPlayersGoalsScored.Location = new Point(129, 36);
            lblPlayersGoalsScored.Name = "lblPlayersGoalsScored";
            lblPlayersGoalsScored.Size = new Size(94, 23);
            lblPlayersGoalsScored.TabIndex = 1;
            lblPlayersGoalsScored.Text = "Goals Scored";
            // 
            // flpGoalsScored
            // 
            flpGoalsScored.AutoScroll = true;
            flpGoalsScored.Location = new Point(12, 62);
            flpGoalsScored.Name = "flpGoalsScored";
            flpGoalsScored.Size = new Size(350, 431);
            flpGoalsScored.TabIndex = 2;
            // 
            // lblRankingsBy
            // 
            lblRankingsBy.AutoSize = true;
            lblRankingsBy.Font = new Font("Sitka Banner", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblRankingsBy.Location = new Point(510, 9);
            lblRankingsBy.Name = "lblRankingsBy";
            lblRankingsBy.Size = new Size(64, 23);
            lblRankingsBy.TabIndex = 3;
            lblRankingsBy.Text = "Rank By";
            // 
            // flpYellowCards
            // 
            flpYellowCards.AutoScroll = true;
            flpYellowCards.Location = new Point(375, 62);
            flpYellowCards.Name = "flpYellowCards";
            flpYellowCards.Size = new Size(350, 431);
            flpYellowCards.TabIndex = 4;
            // 
            // lblYellowCards
            // 
            lblYellowCards.AutoSize = true;
            lblYellowCards.Font = new Font("Sitka Banner", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblYellowCards.Location = new Point(499, 36);
            lblYellowCards.Name = "lblYellowCards";
            lblYellowCards.Size = new Size(94, 23);
            lblYellowCards.TabIndex = 3;
            lblYellowCards.Text = "Yellow Cards";
            // 
            // flpAttendance
            // 
            flpAttendance.AutoScroll = true;
            flpAttendance.Location = new Point(738, 62);
            flpAttendance.Name = "flpAttendance";
            flpAttendance.Size = new Size(350, 431);
            flpAttendance.TabIndex = 6;
            // 
            // lblVenuesByAttendance
            // 
            lblVenuesByAttendance.AutoSize = true;
            lblVenuesByAttendance.Font = new Font("Sitka Banner", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblVenuesByAttendance.Location = new Point(871, 36);
            lblVenuesByAttendance.Name = "lblVenuesByAttendance";
            lblVenuesByAttendance.Size = new Size(82, 23);
            lblVenuesByAttendance.TabIndex = 5;
            lblVenuesByAttendance.Text = "Attendance";
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Location = new Point(510, 548);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(59, 15);
            lblLoading.TabIndex = 7;
            lblLoading.Text = "Loading...";
            // 
            // RankForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1104, 627);
            Controls.Add(lblLoading);
            Controls.Add(flpAttendance);
            Controls.Add(lblVenuesByAttendance);
            Controls.Add(flpYellowCards);
            Controls.Add(lblYellowCards);
            Controls.Add(lblRankingsBy);
            Controls.Add(flpGoalsScored);
            Controls.Add(lblPlayersGoalsScored);
            Name = "RankForm";
            Text = "RankForm";
            Load += RankForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPlayersGoalsScored;
        private FlowLayoutPanel flpGoalsScored;
        private Label lblRankingsBy;
        private FlowLayoutPanel flpYellowCards;
        private Label lblYellowCards;
        private FlowLayoutPanel flpAttendance;
        private Label lblVenuesByAttendance;
        private Label lblLoading;
    }
}