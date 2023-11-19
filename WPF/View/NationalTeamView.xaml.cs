using DAL.Model;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.ViewModel;
using WPFApp;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for NationalTeamView.xaml
    /// </summary>
    public partial class NationalTeamView : Window
    {
        private MatchData match;

        public NationalTeamView()
        {
            InitializeComponent();
            DataContext = new NationalTeamViewModel();
            WindowUtils.SetDesiredResolution(this);
            if (DataContext is NationalTeamViewModel viewModel)
            {
                match = viewModel.SelectedMatch;
            }
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is NationalTeamViewModel viewModel)
            {
                viewModel.UpdateOpponents();
                cbOpponents.SelectedIndex = 0;
                viewModel.OpponentSelectedIndex = cbOpponents.SelectedIndex;

            }
        }

        private void cbOpponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (DataContext is NationalTeamViewModel viewModel)
            {
                if (!(cbOpponents.SelectedIndex < 0))
                {
                    viewModel.UpdateResult(cbOpponents.SelectedIndex);
                    (DataContext as NationalTeamViewModel).OpponentSelectedIndex = cbOpponents.SelectedIndex;
                }
            }
        }

        private void btnCountryDetails_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DetailsView(DataFactory.CountryTeams.First(
                ct => ct.ToString()==cbCountries.SelectedItem.ToString()));
            //Animacija
            dialog.ShowDialog();
        }

        private void btnOpponentDetails_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DetailsView(DataFactory.CountryTeams.First(
                ct => ct.ToString() == cbOpponents.SelectedItem.ToString()));
            //Animacija
            dialog.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddUserControls();
            cbCountries.SelectionChanged += PaintControls;
            cbOpponents.SelectionChanged += PaintControls;
        }

        private void PaintControls(object sender, SelectionChangedEventArgs e)
        {
            AddUserControls();
        }

        private void AddUserControls()
        {
            ClearUserControls();

            bool switchControlSides = true;
            if (DataContext is NationalTeamViewModel viewModel)
            {
                viewModel.OpponentSelectedIndex = cbOpponents.SelectedIndex;
                match = viewModel.SelectedMatch;

                if (match.HomeTeam.ToString().Equals(viewModel.Countries.ElementAt(viewModel.SelectedIndexCountry)))
                {
                    switchControlSides = false;
                }
            }

            if(switchControlSides)
            {
                foreach (var player in match.HomeTeamStatistics.StartingEleven)
                {
                    PlayerControl control;
                    switch (player.Position)
                    {
                        case "Goalie":
                            control = new PlayerControl(player, match);
                            spGuestGoalie.Children.Add(control);
                            break;
                        case "Defender":
                            control = new PlayerControl(player, match);
                            spGuestDefender.Children.Add(control);
                            break;
                        case "Midfield":
                            control = new PlayerControl(player, match);
                            spGuestMidfield.Children.Add(control);
                            break;
                        case "Forward":
                            control = new PlayerControl(player, match);
                            spGuestForward.Children.Add(control);
                            break;
                        default:
                            break;
                    }
                }

                foreach (var player in match.AwayTeamStatistics.StartingEleven)
                {
                    PlayerControl control;
                    switch (player.Position)
                    {
                        case "Goalie":
                            control = new PlayerControl(player, match);
                            spHomeGoalie.Children.Add(control);
                            break;
                        case "Defender":
                            control = new PlayerControl(player, match);
                            spHomeDefender.Children.Add(control);
                            break;
                        case "Midfield":
                            control = new PlayerControl(player, match);
                            spHomeMidfield.Children.Add(control);
                            break;
                        case "Forward":
                            control = new PlayerControl(player, match);
                            spHomeForward.Children.Add(control);
                            break;
                        default:
                            break;
                    }
                }
            } else
            {
                foreach (var player in match.HomeTeamStatistics.StartingEleven)
                {
                    PlayerControl control;
                    switch (player.Position)
                    {
                        case "Goalie":
                            control = new PlayerControl(player, match);
                            spHomeGoalie.Children.Add(control);
                            break;
                        case "Defender":
                            control = new PlayerControl(player, match);
                            spHomeDefender.Children.Add(control);
                            break;
                        case "Midfield":
                            control = new PlayerControl(player, match);
                            spHomeMidfield.Children.Add(control);
                            break;
                        case "Forward":
                            control = new PlayerControl(player, match);
                            spHomeForward.Children.Add(control);
                            break;
                        default:
                            break;
                    }
                }

                foreach (var player in match.AwayTeamStatistics.StartingEleven)
                {
                    PlayerControl control;
                    switch (player.Position)
                    {
                        case "Goalie":
                            control = new PlayerControl(player, match);
                            spGuestGoalie.Children.Add(control);
                            break;
                        case "Defender":
                            control = new PlayerControl(player, match);
                            spGuestDefender.Children.Add(control);
                            break;
                        case "Midfield":
                            control = new PlayerControl(player, match);
                            spGuestMidfield.Children.Add(control);
                            break;
                        case "Forward":
                            control = new PlayerControl(player, match);
                            spGuestForward.Children.Add(control);
                            break;
                        default:
                            break;
                    }
                }
            }
            

        }

        private void ClearUserControls()
        {
            spHomeGoalie.Children.Clear();
            spHomeDefender.Children.Clear();
            spHomeMidfield.Children.Clear();
            spHomeForward.Children.Clear();
            spGuestGoalie.Children.Clear();
            spGuestDefender.Children.Clear();
            spGuestMidfield.Children.Clear();
            spGuestForward.Children.Clear();
        }

        private void mniSettings_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SettingsView();
            dialog.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var dialog = new QuestionView("Are you sure you want to exit?", e);
            dialog.ShowDialog();
        }
    }
}
