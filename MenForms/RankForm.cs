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
using System.Resources;
using DAL;
using System.Globalization;
using Microsoft.VisualBasic;

namespace MenForms
{
    public partial class RankForm : Form, IResponsive
    {
        private ResourceManager rm = new ResourceManager("MenForms.RankForm", typeof(RankForm).Assembly);
        private System.Drawing.Printing.PrintDocument pdPrintRankings = new System.Drawing.Printing.PrintDocument();
        private int cntr = 1;
        bool confirmOnClose = true;
        public RankForm()
        {
            InitializeComponent();
            pdPrintRankings.PrintPage += pdPrintRankings_PrintPage;
            ChangeCulture(Utils.GetLanguageTagFromSettings(DataFactory.AppSettings));

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
            btnNext.Text = rm.GetString("btnNext.Text");
            lblLoading.Text = rm.GetString("lblLoading.Text");
            lblPlayersGoalsScored.Text = rm.GetString("lblPlayersGoalsScored.Text");
            lblRankingsBy.Text = rm.GetString("lblRankingsBy.Text");
            lblVenuesByAttendance.Text = rm.GetString("lblVenuesByAttendance.Text");
            lblYellowCards.Text = rm.GetString("lblYellowCards.Text");
            printPDFToolStripMenuItem.Text = rm.GetString("printPDFToolStripMenuItem.Text");
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

            flpGoalsScored.Controls.Clear();
            flpYellowCards.Controls.Clear();
            flpAttendance.Controls.Clear();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            confirmOnClose = false;
            Close();
        }

        private void printPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pdPrintRankings;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pdPrintRankings.Print();
            }
        }

        private void pdPrintRankings_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            StringBuilder sbPrint = new StringBuilder();
            if (cntr == 1)
            {
                sbPrint.Append("Players by goals scored :");
                sbPrint.Append("\n");
                sbPrint.Append(GetPlayersStringGoals());
                sbPrint.Append("\n\n\n\n");
                sbPrint.Append("Players by yellow cards :");
                sbPrint.Append("\n");
                sbPrint.Append(GetPlayersStringYellowCards());
                sbPrint.Append("\n\n\n\n");
                cntr++;
                e.HasMorePages = true;
            }
            else
            {
                sbPrint.Clear();
                sbPrint.Append("Matches by attendance : ");
                sbPrint.Append('\n');
                sbPrint.Append(GetMatchesByAttendance());
                cntr = 1;
                e.HasMorePages = false;
            }


            string content = sbPrint.ToString();
            Font font = new Font("Arial", 11);
            Brush brush = Brushes.Black;

            RectangleF bounds = e.MarginBounds;


            e.Graphics.DrawString(content, font, brush, bounds);
        }

        private string GetMatchesByAttendance()
        {
            ISet<MatchData> matchData = DataFactory.MatchDataForSelectedCountry;
            var sortedMatchData = matchData.OrderByDescending(match => match.Attendance).ToHashSet();
            var sb = new StringBuilder();
            foreach (var match in sortedMatchData)
            {
                sb.Append(match.HomeTeam.Country);
                sb.Append(" Vs ");
                sb.Append(match.AwayTeam.Country);
                sb.Append(", Venue : ");
                sb.Append(match.Venue);
                sb.Append(", Attendance : ");
                sb.Append(match.Attendance);
                sb.Append('\n');

            }
            return sb.ToString();
        }

        private string GetPlayersStringYellowCards()
        {
            IDictionary<string, PlayerRankingData> playersData = DataFactory.PlayerDataForSelectedCountry;
            var sortedPlayersData = playersData.OrderByDescending(kvp => kvp.Value.YellowCards)
                                           .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var sb = new StringBuilder();
            foreach (var kvp in sortedPlayersData)
            {
                sb.Append("Name : ");
                sb.Append(kvp.Key);
                sb.Append(", Goals scored : ");
                sb.Append(kvp.Value.Goals);
                sb.Append(", Yellow Cards : ");
                sb.Append(kvp.Value.YellowCards);
                sb.Append(", Occurances : ");
                sb.Append(kvp.Value.Occurances);
                sb.Append('\n');
            }
            return sb.ToString();
        }

        private string GetPlayersStringGoals()
        {

            IDictionary<string, PlayerRankingData> playersData = DataFactory.PlayerDataForSelectedCountry;
            var sortedPlayersData = playersData.OrderByDescending(kvp => kvp.Value.Goals)
                                           .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            var sb = new StringBuilder();
            foreach (var kvp in sortedPlayersData)
            {
                sb.Append("Name : ");
                sb.Append(kvp.Key);
                sb.Append(", Goals scored : ");
                sb.Append(kvp.Value.Goals);
                sb.Append(", Yellow Cards : ");
                sb.Append(kvp.Value.YellowCards);
                sb.Append(", Occurances : ");
                sb.Append(kvp.Value.Occurances);
                sb.Append('\n');
            }
            return sb.ToString();
        }

        private void RankForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsPrint.Show(this, e.Location);
            }
        }

        public void ApplyChanges()
        {
            ChangeCulture(Utils.GetLanguageTagFromSettings(DataFactory.AppSettings));
            RankForm_Load(this, new EventArgs());
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm(this);
            form.ShowDialog();
        }

        private void RankForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Console.WriteLine("You chose 'Yes'");
            }
            else
            {
                Console.WriteLine("You chose 'No'");
                e.Cancel = true;
            }
        }

        private void RankForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
