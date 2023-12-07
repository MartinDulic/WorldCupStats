using DAL;
using DAL.Model.Enums;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.Settings;
using System.Globalization;
using System.Resources;

namespace MenForms
{
    public partial class SettingsForm : Form
    {
        readonly ISettingsRepository settingsRepo = RepositoryFactory.GetSettingsRepository();
        ResourceManager rm = new ResourceManager("MenForms.SettingsForm", typeof(SettingsForm).Assembly);
        AppSettings settings = DataFactory.AppSettings;
        IResponsive parentForm;
        public bool ApplyChanges { get; set; } = false;

        public SettingsForm(IResponsive parent)
        {
            InitializeComponent();
            parentForm = parent;

            if (settings.Language == Language.CROATIAN)
            {
                rbCro.Checked = true;
            }
            else
            {
                rbEng.Checked = true;
            }
            if (settings.SelectedChampionship == SelectedChampionship.MEN)
            {
                rbMen.Checked = true;
            }
            else
            {
                rbWomen.Checked = true;
            }
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
            DialogResult result = MessageBox.Show("Apply changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Console.WriteLine("You chose 'Yes'");
                Close();
                return;
            } else
            {
                Console.WriteLine("You chose 'No'");
            }

            if (rbMen.Checked)
            {
                settings.SelectedChampionship = SelectedChampionship.MEN;
            }
            else
            {
                settings.SelectedChampionship = SelectedChampionship.WOMAN;
            }
            if (rbCro.Checked)
            {
                settings.Language = Language.CROATIAN;
            }
            else
            {
                settings.Language = Language.ENGLISH;
            }

            settingsRepo.UpdateSettings(settings);
            parentForm.ApplyChanges();

            Close();

        }

        private void StartingForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}