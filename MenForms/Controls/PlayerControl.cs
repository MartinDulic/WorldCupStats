using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenForms.Controls
{
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }

        private void addToFavouriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Parent.Name == "panelPlayers")
            {
                Parent = Parent.Parent.Controls["panelFavouritePlayers"];
                cmsAddFavourite.Text = "Remove Favourite";
            }
            else if (Parent.Name == "panelFavouritePlayers")
            {
                Parent = Parent.Parent.Controls["panelPlayers"];
                cmsAddFavourite.Text = "Add Favourite";
            }
        }
    }
}
