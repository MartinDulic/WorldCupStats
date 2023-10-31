namespace FormsApp
{
    partial class StartingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingForm));
            gbLanguage = new GroupBox();
            rbEng = new RadioButton();
            rbHrv = new RadioButton();
            rbMans = new RadioButton();
            gbChampionship = new GroupBox();
            rbWomans = new RadioButton();
            btnStart = new Button();
            gbLanguage.SuspendLayout();
            gbChampionship.SuspendLayout();
            SuspendLayout();
            // 
            // gbLanguage
            // 
            resources.ApplyResources(gbLanguage, "gbLanguage");
            gbLanguage.Controls.Add(rbEng);
            gbLanguage.Controls.Add(rbHrv);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.TabStop = false;
            // 
            // rbEng
            // 
            resources.ApplyResources(rbEng, "rbEng");
            rbEng.Checked = true;
            rbEng.Name = "rbEng";
            rbEng.TabStop = true;
            rbEng.UseVisualStyleBackColor = true;
            rbEng.CheckedChanged += rbEng_CheckedChanged;
            // 
            // rbHrv
            // 
            resources.ApplyResources(rbHrv, "rbHrv");
            rbHrv.Name = "rbHrv";
            rbHrv.TabStop = true;
            rbHrv.UseVisualStyleBackColor = true;
            rbHrv.CheckedChanged += rbHrv_CheckedChanged;
            // 
            // rbMans
            // 
            resources.ApplyResources(rbMans, "rbMans");
            rbMans.Checked = true;
            rbMans.Name = "rbMans";
            rbMans.TabStop = true;
            rbMans.UseVisualStyleBackColor = true;
            // 
            // gbChampionship
            // 
            resources.ApplyResources(gbChampionship, "gbChampionship");
            gbChampionship.Controls.Add(rbWomans);
            gbChampionship.Controls.Add(rbMans);
            gbChampionship.Name = "gbChampionship";
            gbChampionship.TabStop = false;
            // 
            // rbWomans
            // 
            resources.ApplyResources(rbWomans, "rbWomans");
            rbWomans.Name = "rbWomans";
            rbWomans.TabStop = true;
            rbWomans.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            resources.ApplyResources(btnStart, "btnStart");
            btnStart.Name = "btnStart";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // StartingForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnStart);
            Controls.Add(gbChampionship);
            Controls.Add(gbLanguage);
            Name = "StartingForm";
            Load += StartingForm_Load;
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
            gbChampionship.ResumeLayout(false);
            gbChampionship.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbLanguage;
        private RadioButton rbEng;
        private RadioButton rbHrv;
        private GroupBox gbChampionship;
        private RadioButton rbWomans;
        private RadioButton rbMans;
        private Button btnStart;
    }
}