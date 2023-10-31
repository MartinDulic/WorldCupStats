using DAL.Repositories;
using System.Globalization;
using System.Resources;
using System.Runtime.Versioning;

namespace FormsApp
{
    public partial class StartingForm : Form
    {

        ResourceManager rm = new ResourceManager("FormsApp.StartingForm", typeof(StartingForm).Assembly);
        public StartingForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rbEng_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCulture("en-US");
        }

        private void rbHrv_CheckedChanged(object sender, EventArgs e)
        {
            ChangeCulture("hr-HR");
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

            gbLanguage.Text = rm.GetString("gbLanguage.Text");
            gbChampionship.Text = rm.GetString("gbChampionship.Text");
            rbEng.Text = rm.GetString("rbEng.Text");
            rbHrv.Text = rm.GetString("rbHrv.Text");
            rbMans.Text = rm.GetString("rbMans.Text");
            rbWomans.Text = rm.GetString("rbWomans.Text");
            btnStart.Text = rm.GetString("btnStart.Text"); 
                                                       
        }

        private void StartingForm_Load(object sender, EventArgs e)
        {

        }
    }
}