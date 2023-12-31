﻿namespace MenForms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
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
            resources.ApplyResources(gbLanguage, "gbLanguage");
            gbLanguage.Controls.Add(rbEng);
            gbLanguage.Controls.Add(rbCro);
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
            rbCro.Checked = true;
            rbCro.Name = "rbCro";
            rbCro.TabStop = true;
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
            rbMen.Checked = true;
            rbMen.Name = "rbMen";
            rbMen.TabStop = true;
            rbMen.UseVisualStyleBackColor = true;
            rbMen.CheckedChanged += rbMen_CheckedChanged;
            // 
            // gbChampionship
            // 
            resources.ApplyResources(gbChampionship, "gbChampionship");
            gbChampionship.Controls.Add(rbWomen);
            gbChampionship.Controls.Add(rbMen);
            gbChampionship.Name = "gbChampionship";
            gbChampionship.TabStop = false;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbChampionship);
            Controls.Add(gbLanguage);
            Controls.Add(btnNext);
            Name = "SettingsForm";
            FormClosing += StartingForm_FormClosing;
            FormClosed += SettingsForm_FormClosed;
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