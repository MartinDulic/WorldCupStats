namespace MenForms.Controls
{
    partial class PlayerControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            lblName = new Label();
            lblPlayerName = new Label();
            lblShirtNumber = new Label();
            lblPlayerShirtNumber = new Label();
            lblPosition = new Label();
            lblPlayerPosition = new Label();
            lblPlayerCapitain = new Label();
            lblCapitain = new Label();
            imgFavourite = new PictureBox();
            imgPlayerImage = new PictureBox();
            cmsAddFavourite = new ContextMenuStrip(components);
            addToFavouriteToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)imgFavourite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imgPlayerImage).BeginInit();
            cmsAddFavourite.SuspendLayout();
            SuspendLayout();
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
            // lblShirtNumber
            // 
            resources.ApplyResources(lblShirtNumber, "lblShirtNumber");
            lblShirtNumber.Name = "lblShirtNumber";
            // 
            // lblPlayerShirtNumber
            // 
            resources.ApplyResources(lblPlayerShirtNumber, "lblPlayerShirtNumber");
            lblPlayerShirtNumber.Name = "lblPlayerShirtNumber";
            // 
            // lblPosition
            // 
            resources.ApplyResources(lblPosition, "lblPosition");
            lblPosition.Name = "lblPosition";
            // 
            // lblPlayerPosition
            // 
            resources.ApplyResources(lblPlayerPosition, "lblPlayerPosition");
            lblPlayerPosition.Name = "lblPlayerPosition";
            // 
            // lblPlayerCapitain
            // 
            resources.ApplyResources(lblPlayerCapitain, "lblPlayerCapitain");
            lblPlayerCapitain.Name = "lblPlayerCapitain";
            // 
            // lblCapitain
            // 
            resources.ApplyResources(lblCapitain, "lblCapitain");
            lblCapitain.Name = "lblCapitain";
            // 
            // imgFavourite
            // 
            resources.ApplyResources(imgFavourite, "imgFavourite");
            imgFavourite.Name = "imgFavourite";
            imgFavourite.TabStop = false;
            // 
            // imgPlayerImage
            // 
            resources.ApplyResources(imgPlayerImage, "imgPlayerImage");
            imgPlayerImage.Name = "imgPlayerImage";
            imgPlayerImage.TabStop = false;
            // 
            // cmsAddFavourite
            // 
            resources.ApplyResources(cmsAddFavourite, "cmsAddFavourite");
            cmsAddFavourite.Items.AddRange(new ToolStripItem[] { addToFavouriteToolStripMenuItem });
            cmsAddFavourite.Name = "cmsAddFavourite";
            // 
            // addToFavouriteToolStripMenuItem
            // 
            resources.ApplyResources(addToFavouriteToolStripMenuItem, "addToFavouriteToolStripMenuItem");
            addToFavouriteToolStripMenuItem.Name = "addToFavouriteToolStripMenuItem";
            addToFavouriteToolStripMenuItem.Click += addToFavouriteToolStripMenuItem_Click;
            // 
            // PlayerControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(imgPlayerImage);
            Controls.Add(imgFavourite);
            Controls.Add(lblPlayerCapitain);
            Controls.Add(lblCapitain);
            Controls.Add(lblPlayerPosition);
            Controls.Add(lblPosition);
            Controls.Add(lblPlayerShirtNumber);
            Controls.Add(lblShirtNumber);
            Controls.Add(lblPlayerName);
            Controls.Add(lblName);
            Name = "PlayerControl";
            ((System.ComponentModel.ISupportInitialize)imgFavourite).EndInit();
            ((System.ComponentModel.ISupportInitialize)imgPlayerImage).EndInit();
            cmsAddFavourite.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblPlayerName;
        private Label lblShirtNumber;
        private Label lblPlayerShirtNumber;
        private Label lblPosition;
        private Label lblPlayerPosition;
        private Label lblPlayerCapitain;
        private Label lblCapitain;
        private PictureBox imgFavourite;
        private PictureBox imgPlayerImage;
        private ContextMenuStrip cmsAddFavourite;
        private ToolStripMenuItem addToFavouriteToolStripMenuItem;

        public string PlayerNameLabel
        {
            get { return lblPlayerName.Text; }
            set { lblPlayerName.Text = value; }
        }

        public int PlayerShirtNumberLabel
        {
            get { return int.Parse(lblPlayerShirtNumber.Text); }
            set { lblPlayerShirtNumber.Text = value.ToString(); }
        }

        public string PlayerPositionLabel
        {
            get { return lblPlayerPosition.Text; }
            set { lblPlayerPosition.Text = value; }
        }

        public string PlayerCaptainLabel
        {
            get { return lblPlayerCapitain.Text; }
            set { lblPlayerCapitain.Text = value; }
        }

        public Image PlayerImagePictureBox
        {
            get { return imgPlayerImage.Image; }
            set { imgPlayerImage.Image = value; }
        }

    }
}
