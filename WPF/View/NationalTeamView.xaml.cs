using DAL.Model;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Media.Animation;
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
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            // Create a Storyboard and add the animation
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeInAnimation);

            // Set the target property for the animation
            Storyboard.SetTarget(fadeInAnimation, dialog);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(UIElement.OpacityProperty));

            // Start the animation
            storyboard.Begin();
            dialog.Opacity = 0;

            dialog.ShowDialog();
        }

        private void btnOpponentDetails_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new DetailsView(DataFactory.CountryTeams.First(
                ct => ct.ToString() == cbOpponents.SelectedItem.ToString()));
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }
            };

            // Create a Storyboard and add the animation
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeInAnimation);

            // Set the target property for the animation
            Storyboard.SetTarget(fadeInAnimation, dialog);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath(UIElement.OpacityProperty));

            // Start the animation
            storyboard.Begin();
            dialog.Opacity = 0;

            dialog.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

            IList<Player> homeGoalies = new List<Player>();
            IList<Player> homeDefenders = new List<Player>();
            IList<Player> homeMidfielders = new List<Player>();
            IList<Player> homeForwards = new List<Player>();

            IList<Player> awayGoalies = new List<Player>();
            IList<Player> awayDefenders = new List<Player>();
            IList<Player> awayMidfielders = new List<Player>();
            IList<Player> awayForwards = new List<Player>();

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += (sender, e) =>
            {

                if (switchControlSides)
                {
                    foreach (var player in match.HomeTeamStatistics.StartingEleven)
                    {
                        PlayerControl control;
                        switch (player.Position)
                        {
                            case "Goalie":
                                awayGoalies.Add(player);
                                break;
                            case "Defender":
                                awayDefenders.Add(player);
                                break;
                            case "Midfield":
                                awayMidfielders.Add(player);
                                break;
                            case "Forward":
                                awayForwards.Add(player);
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
                                homeGoalies.Add(player);
                                break;
                            case "Defender":
                                homeDefenders.Add(player);
                                break;
                            case "Midfield":
                                homeMidfielders.Add(player);
                                break;
                            case "Forward":
                                homeForwards.Add(player);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    foreach (var player in match.HomeTeamStatistics.StartingEleven)
                    {
                        PlayerControl control;
                        switch (player.Position)
                        {
                            case "Goalie":
                                homeGoalies.Add(player);
                                break;
                            case "Defender":
                                homeDefenders.Add(player);
                                break;
                            case "Midfield":
                                homeMidfielders.Add(player);
                                break;
                            case "Forward":
                                homeForwards.Add(player);
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
                                awayGoalies.Add(player);
                                break;
                            case "Defender":
                                awayDefenders.Add(player);
                                break;
                            case "Midfield":
                                awayMidfielders.Add(player);
                                break;
                            case "Forward":
                                awayForwards.Add(player);
                                break;
                            default:
                                break;
                        }
                    }
                }
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {

                CreatePlayerControls(homeGoalies, true, "Goalies");
                CreatePlayerControls(homeDefenders, true, "Defenders");
                CreatePlayerControls(homeMidfielders, true, "Midfields");
                CreatePlayerControls(homeForwards, true, "");

                CreatePlayerControls(awayGoalies, false, "Goalies");
                CreatePlayerControls(awayDefenders, false, "Defenders");
                CreatePlayerControls(awayMidfielders, false, "Midfields");
                CreatePlayerControls(awayForwards, false, "");
            };

            worker.RunWorkerAsync();

            /*if (switchControlSides)
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
            }*/


        }

        private void CreatePlayerControls(IList<Player> players, bool isHomeTeam , string position)
        {

            WrapPanel sp;
            if (isHomeTeam)
            {
                if (position == "Goalies")
                {
                    sp = spHomeGoalie;
                } else if (position == "Defenders")
                {
                    sp = spHomeDefender;
                } else if (position == "Midfields")
                {
                    sp = spHomeMidfield;
                } else
                {
                    sp = spHomeForward;
                }
            } else
            {
                if (position == "Goalies")
                {
                    sp = spGuestGoalie;
                }
                else if (position == "Defenders")
                {
                    sp = spGuestDefender;
                }
                else if (position == "Midfields")
                {
                    sp = spGuestMidfield;
                }
                else
                {
                    sp = spGuestForward;
                }
            }

            foreach (Player player in players)
            {
                sp.Children.Add( new PlayerControl(player, match));
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

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            AddUserControls();
        }
    }
}
