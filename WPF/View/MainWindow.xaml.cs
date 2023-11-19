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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.View;
using WPFApp;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppSettings appSettings = DataFactory.AppSettings;
        public MainWindow()
        {
            InitializeComponent();
            WindowUtils.SetDesiredResolution(this);
            if (appSettings.Resolution == Resolution.fullscreen) { 
                rbFullscreen.IsChecked = true;
            } else
            {
                rbWindowed.IsChecked = true;

                if (appSettings.Resolution == Resolution.r1920x1080)
                {
                    cbResolutions.SelectedIndex = 1;
                } else if (appSettings.Resolution == Resolution.r1600x1200)
                {
                    cbResolutions.SelectedIndex = 2;
                } else
                {
                    cbResolutions.SelectedIndex = 3;
                }
            }
            
            if (appSettings.Language == DAL.Model.Enums.Language.CROATIAN)
            {
                rbCro.IsChecked = true;
            } else 
            { 
                rbEng.IsChecked = true;
            }

            if (appSettings.SelectedChampionship == SelectedChampionship.MEN)
            {
                rbMen.IsChecked = true;
            } else
            {
                RbWomen.IsChecked = true;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
            if (DataFactory.AppSettings.Resolution == Resolution.fullscreen)
            {
                appSettings.Resolution = Resolution.r720x480;
                DataFactory.AppSettings = appSettings;
            }
            WindowUtils.SetDesiredResolution(this);
            cbResolutions.IsEnabled = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            appSettings.Resolution = Resolution.fullscreen;
            DataFactory.AppSettings = appSettings;
            WindowUtils.SetDesiredResolution(this);
            if (cbResolutions!=null) { 
                cbResolutions.IsEnabled = false;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            NationalTeamView nationalTeamView = new NationalTeamView();
            nationalTeamView.Show();

            Close();
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

            DataFactory.AppSettings = appSettings;
            WindowUtils.SetDesiredResolution(this);
        }

        private void rbMen_Checked(object sender, RoutedEventArgs e)
        {
            appSettings.SelectedChampionship = SelectedChampionship.MEN;
            DataFactory.AppSettings = appSettings;
        }

        private void RnWomen_Checked(object sender, RoutedEventArgs e)
        {
            appSettings.SelectedChampionship = SelectedChampionship.WOMAN;
            DataFactory.AppSettings = appSettings;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
