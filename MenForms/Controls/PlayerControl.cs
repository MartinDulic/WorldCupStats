using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using DAL;
using System.Globalization;

namespace MenForms.Controls
{
    public partial class PlayerControl : UserControl
    {
        private ResourceManager rm = new ResourceManager("MenForms.Controls.PlayerControl", typeof(PlayerControl).Assembly);

        public PlayerControl()
        {
            InitializeComponent();
            ChangeCulture(Utils.GetLanguageTagFromSettings(DataFactory.AppSettings));

        }
        private void ChangeCulture(string cultureName)
        {
            CultureInfo newCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            // Update text of controls
            UpdateControlTexts();

            // Invalidate the form to ensure it's redrawn with the updated text
            Invalidate();
            Refresh();
        }

        private void UpdateControlTexts()
        {
            addToFavouriteToolStripMenuItem.Text = rm.GetString("addToFavouriteToolStripMenuItem.Text");
            editPictureToolStripMenuItem.Text = rm.GetString("editPictureToolStripMenuItem.Text");
            lblCapitain.Text = rm.GetString("lblCapitain.Text");
            lblName.Text = rm.GetString("lblName.Text");
            lblPosition.Text = rm.GetString("lblPosition.Text");
            lblShirtNumber.Text = rm.GetString("lblShirtNumber.Text");
        }
        private void addToFavouriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetParentOther(this);
        }



        private void SetParentOther(PlayerControl playerControl)
        {
            if (playerControl.Parent.Name == "panelPlayers")
            {
                playerControl.Parent = playerControl.Parent.Parent.Controls["panelFavouritePlayers"];
            }
            else if (playerControl.Parent.Name == "panelFavouritePlayers")
            {
                playerControl.Parent = playerControl.Parent.Parent.Controls["panelPlayers"];
            }
        }

        private void PlayerControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsAddFavourite.Show(this, e.Location);
            }
        }

        private void PlayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this.Name, DragDropEffects.Move);
            }
        }

        private void editPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the initial directory (optional)
            openFileDialog.InitialDirectory = @"C:\";

            // Set the title of the dialog
            openFileDialog.Title = "Select a Image";

            // Set the filter for the file types
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tiff;*.ico|All Files|*.*";

            // Set the default file extension (optional)
            openFileDialog.DefaultExt = "png";

            // Set whether to allow multiple file selection
            openFileDialog.Multiselect = false;

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PlayerImagePictureBox = Image.FromFile(openFileDialog.FileName);
                var pictureDict = DataFactory.PlayerPitcurePaths;
                string playerName = lblPlayerName.Text;
                if (pictureDict.ContainsKey(playerName))
                {

                    pictureDict[playerName] = openFileDialog.FileName;
                }
                else
                {
                    pictureDict.Add(playerName, openFileDialog.FileName);
                }
                DataFactory.PlayerPitcurePaths = pictureDict;

            }
        }
    }
}
