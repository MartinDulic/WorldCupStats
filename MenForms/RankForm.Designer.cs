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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankForm));
            lblPlayersGoalsScored = new Label();
            lblRankingsBy = new Label();
            lblYellowCards = new Label();
            lblVenuesByAttendance = new Label();
            lblLoading = new Label();
            btnNext = new Button();
            cmsPrint = new ContextMenuStrip(components);
            printPDFToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            flpYellowCards = new FlowLayoutPanel();
            flpGoalsScored = new FlowLayoutPanel();
            flpAttendance = new FlowLayoutPanel();
            cmsPrint.SuspendLayout();
            SuspendLayout();
            // 
            // lblPlayersGoalsScored
            // 
            resources.ApplyResources(lblPlayersGoalsScored, "lblPlayersGoalsScored");
            lblPlayersGoalsScored.Name = "lblPlayersGoalsScored";
            // 
            // lblRankingsBy
            // 
            resources.ApplyResources(lblRankingsBy, "lblRankingsBy");
            lblRankingsBy.Name = "lblRankingsBy";
            // 
            // lblYellowCards
            // 
            resources.ApplyResources(lblYellowCards, "lblYellowCards");
            lblYellowCards.Name = "lblYellowCards";
            // 
            // lblVenuesByAttendance
            // 
            resources.ApplyResources(lblVenuesByAttendance, "lblVenuesByAttendance");
            lblVenuesByAttendance.Name = "lblVenuesByAttendance";
            // 
            // lblLoading
            // 
            resources.ApplyResources(lblLoading, "lblLoading");
            lblLoading.Name = "lblLoading";
            // 
            // btnNext
            // 
            resources.ApplyResources(btnNext, "btnNext");
            btnNext.Name = "btnNext";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // cmsPrint
            // 
            cmsPrint.Items.AddRange(new ToolStripItem[] { printPDFToolStripMenuItem, settingsToolStripMenuItem });
            cmsPrint.Name = "contextMenuStrip1";
            resources.ApplyResources(cmsPrint, "cmsPrint");
            // 
            // printPDFToolStripMenuItem
            // 
            printPDFToolStripMenuItem.Name = "printPDFToolStripMenuItem";
            resources.ApplyResources(printPDFToolStripMenuItem, "printPDFToolStripMenuItem");
            printPDFToolStripMenuItem.Click += printPDFToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // flpYellowCards
            // 
            resources.ApplyResources(flpYellowCards, "flpYellowCards");
            flpYellowCards.Name = "flpYellowCards";
            // 
            // flpGoalsScored
            // 
            resources.ApplyResources(flpGoalsScored, "flpGoalsScored");
            flpGoalsScored.Name = "flpGoalsScored";
            // 
            // flpAttendance
            // 
            resources.ApplyResources(flpAttendance, "flpAttendance");
            flpAttendance.Name = "flpAttendance";
            // 
            // RankForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnNext);
            Controls.Add(lblLoading);
            Controls.Add(flpAttendance);
            Controls.Add(lblVenuesByAttendance);
            Controls.Add(flpYellowCards);
            Controls.Add(lblYellowCards);
            Controls.Add(lblRankingsBy);
            Controls.Add(flpGoalsScored);
            Controls.Add(lblPlayersGoalsScored);
            Name = "RankForm";
            FormClosing += RankForm_FormClosing;
            Load += RankForm_Load;
            MouseClick += RankForm_MouseClick;
            cmsPrint.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPlayersGoalsScored;
        private Label lblRankingsBy;
        private Label lblYellowCards;
        private Label lblVenuesByAttendance;
        private Label lblLoading;
        private Button btnNext;
        private ContextMenuStrip cmsPrint;
        private ToolStripMenuItem printPDFToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private FlowLayoutPanel flpYellowCards;
        private FlowLayoutPanel flpGoalsScored;
        private FlowLayoutPanel flpAttendance;
    }
}