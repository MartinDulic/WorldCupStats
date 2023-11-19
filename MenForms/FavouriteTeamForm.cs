using DAL.Repositories;
using DAL.Settings;
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
using System.Diagnostics;
using DAL.Model.Enums;
using DAL;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;
using DAL.Repositories.Interfaces;

namespace MenForms
{
    public partial class FavouriteTeamForm : Form, IResponsive
    {
        private readonly IFavouriteSettingsRepository favouriteSettingsRepo = RepositoryFactory.GetFavouriteSettingsRepository();
        private readonly IDataRepository dataRepository = RepositoryFactory.GetDataRepository();
        private ResourceManager rm = new ResourceManager("MenForms.FavouriteTeamForm", typeof(FavouriteTeamForm).Assembly);
        private bool confirmOnClose = true;

        public FavouriteTeamForm()
        {
            InitializeComponent();
            ChangeCulture(Utils.GetLanguageTagFromSettings(DataFactory.AppSettings));

        }
        public void ChangeCulture(string cultureName)
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
            lblChooseTeam.Text = rm.GetString("lblChooseTeam.Text");
            brnNext.Text = rm.GetString("brnNext.Text");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FavouriteTeamForm_Load(object sender, EventArgs e)
        {
            if (DataFactory.AppSettings.SelectedChampionship == SelectedChampionship.MEN)
            {
                cbTeams.DataSource =
                    dataRepository.GetAllMenCountryTeamData().ToList().OrderBy(team => team.CountryName).ToList();
            }
            else
            {
                cbTeams.DataSource =
                    dataRepository.GetAllWomenCountryTeamData().ToList().OrderBy(team => team.CountryName).ToList();
            }

        }

        private void FavouriteTeamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (confirmOnClose)
            {
                var dialog = new ClosingConfirmationForm(e);
                dialog.ShowDialog();

            }
            Utils.KillProccess(Utils.PROCCES_NAME);
        }

        private void brnNext_Click(object sender, EventArgs e)
        {
            var selectedTeam =
                dataRepository.GetAllMenCountryTeamData().ToList().OrderBy(team => team.CountryName).
                ToList().ElementAt(cbTeams.SelectedIndex);
            var favouriteSettings = favouriteSettingsRepo.GetSettings();
            favouriteSettings.FavouriteTeam = selectedTeam;
            favouriteSettingsRepo.UpdateSettings(favouriteSettings);

            var form = new FavouritePlayersForm();
            form.Show();

            confirmOnClose = false;
            Close();

        }

        private void postavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm(this);
            form.ShowDialog();
        }

        private void FavouriteTeamForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cms.Show(this, e.Location);
            }
        }

        public void ApplyChanges()
        {
            ChangeCulture(Utils.GetLanguageTagFromSettings(DataFactory.AppSettings));
            FavouriteTeamForm_Load(this, new EventArgs());
        }
    }
}
