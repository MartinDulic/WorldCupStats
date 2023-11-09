namespace MenForms
{
    partial class FavouriteTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouriteTeamForm));
            cbTeams = new ComboBox();
            lblChooseTeam = new Label();
            brnNext = new Button();
            SuspendLayout();
            // 
            // cbTeams
            // 
            resources.ApplyResources(cbTeams, "cbTeams");
            cbTeams.FormattingEnabled = true;
            cbTeams.Name = "cbTeams";
            // 
            // lblChooseTeam
            // 
            resources.ApplyResources(lblChooseTeam, "lblChooseTeam");
            lblChooseTeam.Name = "lblChooseTeam";
            lblChooseTeam.Click += label1_Click;
            // 
            // brnNext
            // 
            resources.ApplyResources(brnNext, "brnNext");
            brnNext.Name = "brnNext";
            brnNext.UseVisualStyleBackColor = true;
            brnNext.Click += brnNext_Click;
            // 
            // FavouriteTeamForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(brnNext);
            Controls.Add(lblChooseTeam);
            Controls.Add(cbTeams);
            Name = "FavouriteTeamForm";
            FormClosing += FavouriteTeamForm_FormClosing;
            Load += FavouriteTeamForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbTeams;
        private Label lblChooseTeam;
        private Button brnNext;
    }
}