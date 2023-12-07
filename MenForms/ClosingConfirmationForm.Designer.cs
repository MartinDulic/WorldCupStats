namespace MenForms
{
    partial class ClosingConfirmationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClosingConfirmationForm));
            lblQuesion = new Label();
            btnYes = new Button();
            btnNo = new Button();
            SuspendLayout();
            // 
            // lblQuesion
            // 
            resources.ApplyResources(lblQuesion, "lblQuesion");
            lblQuesion.Name = "lblQuesion";
            // 
            // btnYes
            // 
            resources.ApplyResources(btnYes, "btnYes");
            btnYes.Name = "btnYes";
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            resources.ApplyResources(btnNo, "btnNo");
            btnNo.Name = "btnNo";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += btnNo_Click;
            // 
            // ClosingConfirmationForm
            // 
            AcceptButton = btnYes;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnNo;
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            Controls.Add(lblQuesion);
            Name = "ClosingConfirmationForm";
            FormClosed += ClosingConfirmationForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuesion;
        private Button btnYes;
        private Button btnNo;
    }
}