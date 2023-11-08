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
            cbTeams = new ComboBox();
            lblChooseTeam = new Label();
            SuspendLayout();
            // 
            // cbTeams
            // 
            cbTeams.FormattingEnabled = true;
            cbTeams.Location = new Point(221, 85);
            cbTeams.Name = "cbTeams";
            cbTeams.Size = new Size(313, 23);
            cbTeams.TabIndex = 0;
            // 
            // lblChooseTeam
            // 
            lblChooseTeam.AutoSize = true;
            lblChooseTeam.Location = new Point(306, 48);
            lblChooseTeam.Name = "lblChooseTeam";
            lblChooseTeam.Size = new Size(130, 15);
            lblChooseTeam.TabIndex = 1;
            lblChooseTeam.Text = "Choose Favourite Team";
            lblChooseTeam.Click += label1_Click;
            // 
            // FavouriteTeamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblChooseTeam);
            Controls.Add(cbTeams);
            Name = "FavouriteTeamForm";
            Text = "FavouriteTeam";
            FormClosing += FavouriteTeamForm_FormClosing;
            Load += FavouriteTeamForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbTeams;
        private Label lblChooseTeam;
    }
}