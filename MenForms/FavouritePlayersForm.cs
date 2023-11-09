using DAL;
using MenForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenForms
{
    public partial class FavouritePlayersForm : Form
    {
        public FavouritePlayersForm()
        {
            try
            {
                var playerControl = new PlayerControl();
                Controls.Add(playerControl);
            }
            catch (Exception)
            {

                throw;
            }

            InitializeComponent();
        }

        private void FavouritePlayersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Utils.KillProccess(Utils.PROCCES_NAME);
        }
    }
}
