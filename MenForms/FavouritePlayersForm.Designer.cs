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
            panelPlayers = new FlowLayoutPanel();
            lblPlayers = new Label();
            lblFavouritePlayers = new Label();
            panelFavouritePlayers = new FlowLayoutPanel();
            btnNext = new Button();
            SuspendLayout();
            // 
            // panelPlayers
            // 
            panelPlayers.Location = new Point(7, 33);
            panelPlayers.Name = "panelPlayers";
            panelPlayers.Size = new Size(512, 1000);
            panelPlayers.TabIndex = 0;
            // 
            // lblPlayers
            // 
            lblPlayers.AutoSize = true;
            lblPlayers.Font = new Font("Copperplate Gothic Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblPlayers.Location = new Point(206, 9);
            lblPlayers.Name = "lblPlayers";
            lblPlayers.Size = new Size(97, 21);
            lblPlayers.TabIndex = 1;
            lblPlayers.Text = "Players";
            // 
            // lblFavouritePlayers
            // 
            lblFavouritePlayers.AutoSize = true;
            lblFavouritePlayers.Font = new Font("Copperplate Gothic Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFavouritePlayers.Location = new Point(721, 9);
            lblFavouritePlayers.Name = "lblFavouritePlayers";
            lblFavouritePlayers.Size = new Size(210, 21);
            lblFavouritePlayers.TabIndex = 3;
            lblFavouritePlayers.Text = "Favourite Players";
            // 
            // panelFavouritePlayers
            // 
            panelFavouritePlayers.Location = new Point(560, 33);
            panelFavouritePlayers.Name = "panelFavouritePlayers";
            panelFavouritePlayers.Size = new Size(512, 600);
            panelFavouritePlayers.TabIndex = 2;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(721, 687);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(210, 35);
            btnNext.TabIndex = 4;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // FavouritePlayersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 1061);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel panelPlayers;
        private Label lblPlayers;
        private Label lblFavouritePlayers;
        private FlowLayoutPanel panelFavouritePlayers;
        private Button btnNext;

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