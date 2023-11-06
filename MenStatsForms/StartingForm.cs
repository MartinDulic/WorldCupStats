using System.Resources;

namespace MenStatsForms
{
    public partial class StartingForm : Form
    {
        ResourceManager rm = new ResourceManager("FormsApp.StartingForm", typeof(StartingForm).Assembly);
        public StartingForm()
        {
            InitializeComponent();
        }


    }
}