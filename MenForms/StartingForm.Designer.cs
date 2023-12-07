namespace MenForms
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
            btnNext = new Button();
            gbLanguage = new GroupBox();
            rbEng = new RadioButton();
            rbCro = new RadioButton();
            rbWomen = new RadioButton();
            rbMen = new RadioButton();
            gbChampionship = new GroupBox();
            gbLanguage.SuspendLayout();
            gbChampionship.SuspendLayout();
            SuspendLayout();
            // 
            // btnNext
            // 
            resources.ApplyResources(btnNext, "btnNext");
            btnNext.Name = "btnNext";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // gbLanguage
            // 
            gbLanguage.Controls.Add(rbEng);
            gbLanguage.Controls.Add(rbCro);
            resources.ApplyResources(gbLanguage, "gbLanguage");
            gbLanguage.Name = "gbLanguage";
            gbLanguage.TabStop = false;
            // 
            // rbEng
            // 
            resources.ApplyResources(rbEng, "rbEng");
            rbEng.Name = "rbEng";
            rbEng.UseVisualStyleBackColor = true;
            rbEng.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // rbCro
            // 
            resources.ApplyResources(rbCro, "rbCro");
            rbCro.Name = "rbCro";
            rbCro.UseVisualStyleBackColor = true;
            rbCro.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rbWomen
            // 
            resources.ApplyResources(rbWomen, "rbWomen");
            rbWomen.Name = "rbWomen";
            rbWomen.UseVisualStyleBackColor = true;
            rbWomen.CheckedChanged += rbWomen_CheckedChanged;
            // 
            // rbMen
            // 
            resources.ApplyResources(rbMen, "rbMen");
            rbMen.Name = "rbMen";
            rbMen.UseVisualStyleBackColor = true;
            rbMen.CheckedChanged += rbMen_CheckedChanged;
            // 
            // gbChampionship
            // 
            gbChampionship.Controls.Add(rbWomen);
            gbChampionship.Controls.Add(rbMen);
            resources.ApplyResources(gbChampionship, "gbChampionship");
            gbChampionship.Name = "gbChampionship";
            gbChampionship.TabStop = false;
            // 
            // StartingForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbChampionship);
            Controls.Add(gbLanguage);
            Controls.Add(btnNext);
            Name = "StartingForm";
            FormClosing += StartingForm_FormClosing;
            FormClosed += StartingForm_FormClosed;
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
            gbChampionship.ResumeLayout(false);
            gbChampionship.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNext;
        private GroupBox gbLanguage;
        private RadioButton rbEng;
        private RadioButton rbCro;
        private RadioButton rbWomen;
        private RadioButton rbMen;
        private GroupBox gbChampionship;
    }
}