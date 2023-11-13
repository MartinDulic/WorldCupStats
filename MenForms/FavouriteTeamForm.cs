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

namespace MenForms
{
    public partial class FavouriteTeamForm : Form
    {
        private readonly ISettingsRepository appSettingsRepo = RepositoryFactory.GetSettingsRepository();
        private readonly IFavouriteSettingsRepository favouriteSettingsRepo = RepositoryFactory.GetFavouriteSettingsRepository();
        private readonly IDataRepository dataRepository = RepositoryFactory.GetDataRepository();
        private ResourceManager rm = new ResourceManager("MenForms.FavouriteTeamForm", typeof(FavouriteTeamForm).Assembly);

        public FavouriteTeamForm()
        {
            InitializeComponent();
            if (appSettingsRepo.GetSettings().Language == Language.CROATIAN)
            {

                lblChooseTeam.Text = rm.GetString("lblChooseTeam.Text");
                brnNext.Text = rm.GetString("brnNext.Text");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FavouriteTeamForm_Load(object sender, EventArgs e)
        {
            
            cbTeams.DataSource = 
                dataRepository.GetAllMenCountryTeamData().ToList().OrderBy(team => team.CountryName).ToList();
        }

        private void FavouriteTeamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
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

            Close();
            Dispose();
            Utils.KillProccess(Utils.PROCCES_NAME);

        }
    }
}
