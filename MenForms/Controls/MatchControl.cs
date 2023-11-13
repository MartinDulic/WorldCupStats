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
using DAL.Repositories;
using DAL;
using System.Globalization;

namespace MenForms.Controls
{
    public partial class MatchControl : UserControl
    {
        private ResourceManager rm = new ResourceManager("MenForms.Controls.PlayerRankControl", typeof(PlayerRankControl).Assembly);

        public MatchControl()
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
            lblAttendance.Text = rm.GetString("lblAttendance.Text");
            lblVenue.Text = rm.GetString("lblVenue.Text");
            lblVs.Text = rm.GetString("lblVs.Text");
        }
    }
}
