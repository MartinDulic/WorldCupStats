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
            panelPlayers = new FlowLayoutPanel();
            lblPlayers = new Label();
            lblFavouritePlayers = new Label();
            panelFavouritePlayers = new FlowLayoutPanel();
            btnNext = new Button();
            lblLoading = new Label();
            cmsAddAll = new ContextMenuStrip(components);
            addSelectionToolStripMenuItem = new ToolStripMenuItem();
            cmsAddAll.SuspendLayout();
            SuspendLayout();
            // 
            // panelPlayers
            // 
            panelPlayers.AllowDrop = true;
            panelPlayers.AutoScroll = true;
            panelPlayers.Location = new Point(7, 33);
            panelPlayers.Name = "panelPlayers";
            panelPlayers.Size = new Size(700, 1000);
            panelPlayers.TabIndex = 0;
            panelPlayers.DragDrop += panelPlayers_DragDrop;
            // 
            // lblPlayers
            // 
            lblPlayers.AutoSize = true;
            lblPlayers.Font = new Font("Copperplate Gothic Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlayers.Location = new Point(303, 9);
            lblPlayers.Name = "lblPlayers";
            lblPlayers.Size = new Size(97, 21);
            lblPlayers.TabIndex = 1;
            lblPlayers.Text = "Players";
            // 
            // lblFavouritePlayers
            // 
            lblFavouritePlayers.AutoSize = true;
            lblFavouritePlayers.Font = new Font("Copperplate Gothic Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFavouritePlayers.Location = new Point(978, 9);
            lblFavouritePlayers.Name = "lblFavouritePlayers";
            lblFavouritePlayers.Size = new Size(210, 21);
            lblFavouritePlayers.TabIndex = 3;
            lblFavouritePlayers.Text = "Favourite Players";
            // 
            // panelFavouritePlayers
            // 
            panelFavouritePlayers.AllowDrop = true;
            panelFavouritePlayers.Location = new Point(734, 33);
            panelFavouritePlayers.Name = "panelFavouritePlayers";
            panelFavouritePlayers.Size = new Size(700, 700);
            panelFavouritePlayers.TabIndex = 2;
            panelFavouritePlayers.DragDrop += panelFavouritePlayers_DragDrop;
            panelFavouritePlayers.DragEnter += panelFavouritePlayers_DragEnter;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(978, 749);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(210, 35);
            btnNext.TabIndex = 4;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Location = new Point(978, 819);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(50, 15);
            lblLoading.TabIndex = 5;
            lblLoading.Text = "Loading";
            // 
            // cmsAddAll
            // 
            cmsAddAll.Items.AddRange(new ToolStripItem[] { addSelectionToolStripMenuItem });
            cmsAddAll.Name = "cmsAddAll";
            cmsAddAll.Size = new Size(148, 26);
            // 
            // addSelectionToolStripMenuItem
            // 
            addSelectionToolStripMenuItem.Name = "addSelectionToolStripMenuItem";
            addSelectionToolStripMenuItem.Size = new Size(147, 22);
            addSelectionToolStripMenuItem.Text = "Add Selection";
            addSelectionToolStripMenuItem.Click += addSelectionToolStripMenuItem_Click;
            // 
            // FavouritePlayersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1484, 1061);
            Controls.Add(lblLoading);
            Controls.Add(btnNext);
            Controls.Add(lblFavouritePlayers);
            Controls.Add(panelFavouritePlayers);
            Controls.Add(lblPlayers);
            Controls.Add(panelPlayers);
            Name = "FavouritePlayersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FavouritePlayersForm";
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