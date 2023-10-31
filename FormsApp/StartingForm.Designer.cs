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
            gbLanguage.Controls.Add(rbEng);
            gbLanguage.Controls.Add(rbHrv);
            gbLanguage.Location = new Point(280, 188);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.Size = new Size(200, 100);
            gbLanguage.TabIndex = 0;
            gbLanguage.TabStop = false;
            gbLanguage.Text = "Choose Language";
            // 
            // rbEng
            // 
            rbEng.AutoSize = true;
            rbEng.Checked = true;
            rbEng.Location = new Point(45, 57);
            rbEng.Name = "rbEng";
            rbEng.Size = new Size(63, 19);
            rbEng.TabIndex = 1;
            rbEng.TabStop = true;
            rbEng.Text = "English";
            rbEng.UseVisualStyleBackColor = true;
            // 
            // rbHrv
            // 
            rbHrv.AutoSize = true;
            rbHrv.Location = new Point(45, 32);
            rbHrv.Name = "rbHrv";
            rbHrv.Size = new Size(68, 19);
            rbHrv.TabIndex = 0;
            rbHrv.TabStop = true;
            rbHrv.Text = "Hrvatski";
            rbHrv.UseVisualStyleBackColor = true;
            // 
            // rbMans
            // 
            rbMans.AutoSize = true;
            rbMans.Checked = true;
            rbMans.Location = new Point(45, 32);
            rbMans.Name = "rbMans";
            rbMans.Size = new Size(54, 19);
            rbMans.TabIndex = 0;
            rbMans.TabStop = true;
            rbMans.Text = "Mans";
            rbMans.UseVisualStyleBackColor = true;
            // 
            // gbChampionship
            // 
            gbChampionship.Controls.Add(rbWomans);
            gbChampionship.Controls.Add(rbMans);
            gbChampionship.Location = new Point(280, 72);
            gbChampionship.Name = "gbChampionship";
            gbChampionship.Size = new Size(200, 100);
            gbChampionship.TabIndex = 2;
            gbChampionship.TabStop = false;
            gbChampionship.Text = "Choose Championship";
            // 
            // rbWomans
            // 
            rbWomans.AutoSize = true;
            rbWomans.Location = new Point(45, 57);
            rbWomans.Name = "rbWomans";
            rbWomans.Size = new Size(72, 19);
            rbWomans.TabIndex = 1;
            rbWomans.TabStop = true;
            rbWomans.Text = "Womans";
            rbWomans.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(280, 313);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(200, 29);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStart);
            Controls.Add(gbChampionship);
            Controls.Add(gbLanguage);
            Name = "Form1";
            Text = "Form1";
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