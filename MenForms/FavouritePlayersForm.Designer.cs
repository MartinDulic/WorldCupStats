namespace MenForms
{
    partial class FavouritePlayersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavouritePlayersForm));
            panelPlayers = new FlowLayoutPanel();
            lblPlayers = new Label();
            lblFavouritePlayers = new Label();
            panelFavouritePlayers = new FlowLayoutPanel();
            btnNext = new Button();
            lblLoading = new Label();
            cmsAddAll = new ContextMenuStrip(components);
            addSelectionToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            cmsAddAll.SuspendLayout();
            SuspendLayout();
            // 
            // panelPlayers
            // 
            resources.ApplyResources(panelPlayers, "panelPlayers");
            panelPlayers.AllowDrop = true;
            panelPlayers.Name = "panelPlayers";
            panelPlayers.DragDrop += panelPlayers_DragDrop;
            // 
            // lblPlayers
            // 
            resources.ApplyResources(lblPlayers, "lblPlayers");
            lblPlayers.Name = "lblPlayers";
            // 
            // lblFavouritePlayers
            // 
            resources.ApplyResources(lblFavouritePlayers, "lblFavouritePlayers");
            lblFavouritePlayers.Name = "lblFavouritePlayers";
            // 
            // panelFavouritePlayers
            // 
            resources.ApplyResources(panelFavouritePlayers, "panelFavouritePlayers");
            panelFavouritePlayers.AllowDrop = true;
            panelFavouritePlayers.Name = "panelFavouritePlayers";
            panelFavouritePlayers.DragDrop += panelFavouritePlayers_DragDrop;
            panelFavouritePlayers.DragEnter += panelFavouritePlayers_DragEnter;
            // 
            // btnNext
            // 
            resources.ApplyResources(btnNext, "btnNext");
            btnNext.Name = "btnNext";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblLoading
            // 
            resources.ApplyResources(lblLoading, "lblLoading");
            lblLoading.Name = "lblLoading";
            // 
            // cmsAddAll
            // 
            resources.ApplyResources(cmsAddAll, "cmsAddAll");
            cmsAddAll.Items.AddRange(new ToolStripItem[] { addSelectionToolStripMenuItem, settingsToolStripMenuItem });
            cmsAddAll.Name = "cmsAddAll";
            // 
            // addSelectionToolStripMenuItem
            // 
            resources.ApplyResources(addSelectionToolStripMenuItem, "addSelectionToolStripMenuItem");
            addSelectionToolStripMenuItem.Name = "addSelectionToolStripMenuItem";
            addSelectionToolStripMenuItem.Click += addSelectionToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // FavouritePlayersForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblLoading);
            Controls.Add(btnNext);
            Controls.Add(lblFavouritePlayers);
            Controls.Add(panelFavouritePlayers);
            Controls.Add(lblPlayers);
            Controls.Add(panelPlayers);
            Name = "FavouritePlayersForm";
            FormClosing += FavouritePlayersForm_FormClosing;
            Load += FavouritePlayersForm_Load;
            MouseClick += FavouritePlayersForm_MouseClick;
            cmsAddAll.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel panelPlayers;
        private Label lblPlayers;
        private Label lblFavouritePlayers;
        private FlowLayoutPanel panelFavouritePlayers;
        private Button btnNext;
        private Label lblLoading;
        private List<Control> selectedControls = new List<Control>();
        private ContextMenuStrip cmsAddAll;
        private ToolStripMenuItem addSelectionToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;

        public IList<Control> SelectedControls
        {
            get { return selectedControls; }
        }

        public FlowLayoutPanel PanelPlayers
        {
            get { return panelPlayers; }
        }

        public FlowLayoutPanel PanelFavouritePlayers
        {
            get { return panelFavouritePlayers; }
        }

    }
}