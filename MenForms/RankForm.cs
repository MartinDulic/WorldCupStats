using DAL.Model;
using DAL.Repositories;
using MenForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MenForms
{
    public partial class RankForm : Form
    {
        public RankForm()
        {
            InitializeComponent();
        }
        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            // Toggle visibility of the label
            lblLoading.Visible = false;
            Thread.Sleep(500);
            lblLoading.Visible = true;
        }
        private void RankForm_Load(object sender, EventArgs e)
        {
            var blinkTimer = new System.Windows.Forms.Timer();
            blinkTimer.Interval = 1000; // Set the interval to 1000 milliseconds (1 second)
            blinkTimer.Tick += BlinkTimer_Tick;
            blinkTimer.Start();

            Control[] controlsByGoals = new Control[0];
            Control[] controlsByYellowCards = new Control[0];
            Control[] controlsByAttendance = new Control[0];
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += (sender, e) =>
            {
                controlsByGoals = CreatePlayerControlsOrderByGoals();
                controlsByYellowCards = CreatePlayerControlsOrderByYellowCards();
                controlsByAttendance = CreateMatchControlsOrderByAttendanceForSelectedCountry();
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                flpGoalsScored.Controls.AddRange(controlsByGoals);
                flpYellowCards.Controls.AddRange(controlsByYellowCards);
                flpAttendance.Controls.AddRange(controlsByAttendance);

                blinkTimer.Stop();
                lblLoading.Visible = false;
            };

            worker.RunWorkerAsync();
        }

        private Control[] CreateMatchControlsOrderByAttendanceForSelectedCountry()
        {
            ISet<MatchControl> matchControls = new HashSet<MatchControl>();
            ISet<MatchData> matchData = DataFactory.MatchDataForSelectedCountry;
            var sortedMatchData = matchData.OrderByDescending(match => match.Attendance).ToHashSet();

            foreach (var match in sortedMatchData)
            {

                MatchControl matchControl = new MatchControl();
                matchControl.HomeCountry = match.HomeTeamCountry;
                matchControl.AwayCountry = match.AwayTeamCountry;
                matchControl.Venue = match.Venue;
                matchControl.Attendance = int.Parse(match.Attendance);
                matchControls.Add(matchControl);
            }
            return matchControls.ToArray();
        }

        private static Control[] CreatePlayerControlsOrderByGoals()
        {
            try
            {

                ISet<PlayerRankControl> controls = new HashSet<PlayerRankControl>();
                int rank = 1;
                IDictionary<string, PlayerRankingData> playersData = DataFactory.PlayerDataForSelectedCountry;
                var sortedPlayersData = playersData.OrderByDescending(kvp => kvp.Value.Goals)
                                               .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                foreach (var playerData in sortedPlayersData)
                {
                    var control = new PlayerRankControl();
                    control.lblPlayerRankTxt = rank;
                    rank++;
                    control.lblNameTxt = playerData.Key;
                    control.lblNumberOfOccurancesTxt = playerData.Value.Occurances;
                    control.lblPlayerfNumberOfYellowCardsTxt = playerData.Value.YellowCards;
                    control.lblPlayerNumberOfGoalsTxt = playerData.Value.Goals;

                    if (DataFactory.PlayerPitcurePaths.ContainsKey(control.lblNameTxt))
                    {
                        string path;
                        DataFactory.PlayerPitcurePaths.TryGetValue(control.lblNameTxt, out path);

                        control.PlayerImage = Image.FromFile(path);
                    }
                    else
                    {
                        control.PlayerImage = Image.FromFile(DataFactory.PLAYER_PICTURES_PATH + 1 +
                                DataFactory.PLAYER_PICTURES_EXTENSION);
                    }
                    controls.Add(control);
                }
                return controls.ToArray();
            }
            catch (Exception)
            {
                throw;
            }

        }
        private static Control[] CreatePlayerControlsOrderByYellowCards()
        {
            try
            {

                ISet<PlayerRankControl> controls = new HashSet<PlayerRankControl>();
                int rank = 1;
                IDictionary<string, PlayerRankingData> playersData = DataFactory.PlayerDataForSelectedCountry;
                var sortedPlayersData = playersData.OrderByDescending(kvp => kvp.Value.YellowCards)
                                               .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                foreach (var playerData in sortedPlayersData)
                {
                    var control = new PlayerRankControl();
                    control.lblPlayerRankTxt = rank;
                    rank++;
                    control.lblNameTxt = playerData.Key;
                    control.lblNumberOfOccurancesTxt = playerData.Value.Occurances;
                    control.lblPlayerfNumberOfYellowCardsTxt = playerData.Value.YellowCards;
                    control.lblPlayerNumberOfGoalsTxt = playerData.Value.Goals;

                    if (DataFactory.PlayerPitcurePaths.ContainsKey(control.lblNameTxt))
                    {
                        string path;
                        DataFactory.PlayerPitcurePaths.TryGetValue(control.lblNameTxt, out path);

                        control.PlayerImage = Image.FromFile(path);
                    }
                    else
                    {
                        control.PlayerImage = Image.FromFile(DataFactory.PLAYER_PICTURES_PATH + 1 +
                                DataFactory.PLAYER_PICTURES_EXTENSION);
                    }
                    controls.Add(control);
                }
                return controls.ToArray();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
