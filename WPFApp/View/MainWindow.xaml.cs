using DAL.Repositories;
using DAL.Settings;
using DAL.Model.Enums;
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

namespace WPFApp
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
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
            WindowUtils.SetDesiredResolution(this);
            cbResolutions.IsEnabled = true;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            if (cbResolutions!=null) { 
                cbResolutions.IsEnabled = false;
            }
        }



        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

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
                    appSettings.Resolution = Resolution.fullscreen;
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
    }
}
