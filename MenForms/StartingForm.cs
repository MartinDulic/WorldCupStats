using DAL;
using DAL.Model.Enums;
using DAL.Repositories;
using DAL.Settings;
using System.Globalization;
using System.Resources;

namespace MenForms
{
    public partial class StartingForm : Form
    {
        readonly ISettingsRepository settingsRepo = RepositoryFactory.GetSettingsRepository();
        ResourceManager rm = new ResourceManager("MenForms.StartingForm", typeof(StartingForm).Assembly);
        AppSettings settings = new AppSettings();

        public StartingForm()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCulture("hr-HR");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCulture("en-US");
        }

        private void rbMen_CheckedChanged(object sender, EventArgs e)
        {
            settings.SelectedChampionship = SelectedChampionship.MEN;
        }

        private void rbWomen_CheckedChanged(object sender, EventArgs e)
        {
            settings.SelectedChampionship = SelectedChampionship.WOMAN;
        }

        private void ChangeCulture(string cultureName)
        {
            CultureInfo newCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            // Update text of controls
            UpdateControlTexts();

            Utils.SetSettingsLanguageByTag(settings, cultureName);

            // Invalidate the form to ensure it's redrawn with the updated text
            Invalidate();
            Refresh();
        }

        private void UpdateControlTexts()
        {
            gbLanguage.Text = rm.GetString("gbLanguage.Text");
            gbChampionship.Text = rm.GetString("gbChampionship.Text");
            rbEng.Text = rm.GetString("rbEng.Text");
            rbCro.Text = rm.GetString("rbCro.Text");
            rbMen.Text = rm.GetString("rbMen.Text");
            rbWomen.Text = rm.GetString("rbWomen.Text");
            btnNext.Text = rm.GetString("btnNext.Text");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            settingsRepo.UpdateSettings(settings);
            settings = settingsRepo.GetSettings();
            try
            {

                if (settings.SelectedChampionship == SelectedChampionship.MEN)
                {

                    var form = new FavouriteTeamForm();
                    form.Show();

                }
                else
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
            Close();
            Dispose();
            Utils.KillProccess(Utils.PROCCES_NAME);

        }

        private void StartingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Utils.KillProccess(Utils.PROCCES_NAME);
        }
    }
}