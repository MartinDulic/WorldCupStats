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


namespace MenForms
{
    public partial class FavouriteTeamForm : Form
    {
        readonly ISettingsRepository settingsRepo = RepositoryFactory.GetSettingsRepository();
        readonly IDataRepository dataRepository = RepositoryFactory.GetDataRepository();
        AppSettings settings = new AppSettings();
        ResourceManager rm = new ResourceManager("MenForms.FavouriteTeamsForm", typeof(FavouriteTeamForm).Assembly);

        public FavouriteTeamForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FavouriteTeamForm_Load(object sender, EventArgs e)
        {
            cbTeams.DataSource = dataRepository.GetAllMenCountryTeamData().ToList();
        }

        private void FavouriteTeamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }
    }
}
