using DAL.Model.Enums;
using DAL.Repositories;
using DAL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFApp;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        AppSettings appSettings = DataFactory.AppSettings;
        public bool ApplySettings { get; set; } = false;
        public SettingsView()
        {
            InitializeComponent();
            WindowUtils.SetDesiredResolution(this);
            if (appSettings.Resolution == Resolution.fullscreen)
            {
                rbFullscreen.IsChecked = true;
            }
            else
            {
                rbWindowed.IsChecked = true;

                if (appSettings.Resolution == Resolution.r1920x1080)
                {
                    cbResolutions.SelectedIndex = 1;
                }
                else if (appSettings.Resolution == Resolution.r1600x1200)
                {
                    cbResolutions.SelectedIndex = 2;
                }
                else
                {
                    cbResolutions.SelectedIndex = 3;
                }
            }

            if (appSettings.Language == DAL.Model.Enums.Language.CROATIAN)
            {
                rbCro.IsChecked = true;
            }
            else
            {
                rbEng.IsChecked = true;
            }

            if (appSettings.SelectedChampionship == SelectedChampionship.MEN)
            {
                rbMen.IsChecked = true;
            }
            else
            {
                RbWomen.IsChecked = true;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (DataFactory.AppSettings.Resolution == Resolution.fullscreen)
            {
                appSettings.Resolution = Resolution.r720x480;
            }
            if (btnApply != null)
            {
                btnApply.IsEnabled = true;
            }
            cbResolutions.IsEnabled = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            appSettings.Resolution = Resolution.fullscreen;
            if (btnApply != null)
            {
                btnApply.IsEnabled = true;
            }
            if (cbResolutions != null)
            {
                cbResolutions.IsEnabled = false;
            }
        }
        private void cbResolutions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbResolutions.SelectedIndex)
            {
                case 1:
                    appSettings.Resolution = Resolution.r1920x1080;
                    break;
                case 2:
                    appSettings.Resolution = Resolution.r1600x1200;
                    break;
                case 3:
                    appSettings.Resolution = Resolution.r720x480;
                    break;
                default:
                    appSettings.Resolution = DataFactory.AppSettings.Resolution;
                    break;
            }

            if (btnApply != null)
            {
                btnApply.IsEnabled = true;
            }
        }

        private void rbMen_Checked(object sender, RoutedEventArgs e)
        {
            appSettings.SelectedChampionship = SelectedChampionship.MEN;
            if (btnApply != null)
            {
                btnApply.IsEnabled = true;
            }
        }

        private void RnWomen_Checked(object sender, RoutedEventArgs e)
        {
            appSettings.SelectedChampionship = SelectedChampionship.WOMAN;
            if (btnApply != null)
            {
                btnApply.IsEnabled = true;
            }
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new QuestionView("Apply changes?", e);
            dialog.ShowDialog();
            if (ApplySettings)
            {
                DataFactory.AppSettings = appSettings;
                WindowUtils.SetDesiredResolution(this);
            }
            btnApply.IsEnabled = false;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnApply.IsEnabled = false;
        }
    }
}
