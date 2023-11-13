using DAL;
using DAL.Model;
using DAL.Repositories;
using MenForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace MenForms
{
    public partial class FavouritePlayersForm : Form
    {
        private ResourceManager rm = new ResourceManager("MenForms.FavouritePlayersForm", typeof(FavouritePlayersForm).Assembly);

        public FavouritePlayersForm()
        {

            InitializeComponent();
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
            lblFavouritePlayers.Text = rm.GetString("lblFavouritePlayers.Text");
            lblLoading.Text = rm.GetString("lblLoading.Text");
            lblPlayers.Text = rm.GetString("lblPlayers.Text");
        }
        private void FavouritePlayersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Utils.KillProccess(Utils.PROCCES_NAME);
        }
        private void BlinkTimer_Tick(object sender, EventArgs e)
        {
            // Toggle visibility of the label
            lblLoading.Visible = false;
            Thread.Sleep(500);
            lblLoading.Visible = true;
        }
        private void FavouritePlayersForm_Load(object sender, EventArgs e)
        {
            var blinkTimer = new System.Windows.Forms.Timer();
            blinkTimer.Interval = 1000; // Set the interval to 1000 milliseconds (1 second)
            blinkTimer.Tick += BlinkTimer_Tick;
            blinkTimer.Start();

            Control[] controls = new Control[0];
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += (sender, e) =>
            {
                controls = CreatePlayerControls();
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                panelPlayers.Controls.AddRange(controls);
                blinkTimer.Stop();
                lblLoading.Visible = false;
            };

            worker.RunWorkerAsync();
        }



        private Control[] CreatePlayerControls()
        {
            try
            {
                IList<PlayerControl> controls = new List<PlayerControl>();
                foreach (var player in DataFactory.Players)
                {

                    var control = new PlayerControl();
                    control.PlayerNameLabel = player.Name;
                    control.PlayerPositionLabel = player.Position;
                    control.PlayerShirtNumberLabel = (int)player.ShirtNumber;

                    if (player.Captain == true)
                    {
                        control.PlayerCaptainLabel = "Yes";
                    }
                    else
                    {
                        control.PlayerCaptainLabel = "No";
                    }
                    foreach (var favPlayer in DataFactory.FavouriteSettings.FavouritePlayers)
                    {
                        if (favPlayer != null)
                        {
                            if (favPlayer.Equals(player))
                            {
                                Invoke((MethodInvoker)delegate
                                {
                                    control.FavouriteStar = true;
                                });
                            }
                        }
                    }

                    if (DataFactory.PlayerPitcurePaths.ContainsKey(control.PlayerNameLabel))
                    {
                        string path;
                        DataFactory.PlayerPitcurePaths.TryGetValue(control.PlayerNameLabel, out path);

                        control.PlayerImagePictureBox = Image.FromFile(path);

                    }
                    else
                    {
                        control.PlayerImagePictureBox = Image.FromFile(DataFactory.PLAYER_PICTURES_PATH + 1 +
                            DataFactory.PLAYER_PICTURES_EXTENSION);
                    }
                    control.MouseDown += Control_MouseDown;
                    control.MouseUp += Control_MouseUp;

                    controls.Add(control);
                }

                return controls.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control clickedControl = sender as Control;

                // If the Ctrl key is not pressed, clear the previous selection
                if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
                {
                    selectedControls.ForEach(control => control.BackColor = Color.White);
                    selectedControls.Clear();
                }

                // Add the clicked control to the selection
                if (!selectedControls.Contains(clickedControl) && selectedControls.Count < 3)
                {
                    clickedControl.BackColor = Color.AliceBlue;
                    selectedControls.Add(clickedControl);
                }
            }
        }
        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            selectedControls.Clear();
        }

        private void panelPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                control.Parent.Controls.Remove(control);
                var panel = sender as FlowLayoutPanel;
                ((FlowLayoutPanel)sender).Controls.Add(control);
            }
        }

        private void panelFavouritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                var name = e.Data.GetData(typeof(string)) as string;
                var control = this.Controls.Find(name, true).FirstOrDefault();
                if (control != null)
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
        }

        private void panelFavouritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            PlayerControl control = (PlayerControl)this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                if (((FlowLayoutPanel)sender).Controls.Count >= 3)
                {
                    MessageBox.Show("Cannot add more than three Players!");
                    return;
                }

                if (((FlowLayoutPanel)sender).Controls.OfType<PlayerControl>().Any(c => c.PlayerNameLabel == control.PlayerNameLabel))
                {
                    MessageBox.Show("Player already in Favorites!");
                    return;
                }
                var newControl = new PlayerControl();
                newControl.Name = $"PlayerControl_{Guid.NewGuid()}";
                newControl.PlayerNameLabel = control.PlayerNameLabel;
                newControl.PlayerShirtNumberLabel = control.PlayerShirtNumberLabel;
                newControl.PlayerPositionLabel = control.PlayerPositionLabel;
                newControl.PlayerCaptainLabel = control.PlayerCaptainLabel;
                newControl.PlayerImagePictureBox = control.PlayerImagePictureBox;
                ((FlowLayoutPanel)sender).Controls.Add(newControl);
                panelPlayers.Controls.Remove(control);
            }
        }
        private void SetParentOther(PlayerControl playerControl)
        {
            if (playerControl.Parent.Name == "panelPlayers")
            {
                playerControl.Parent = playerControl.Parent.Parent.Controls["panelFavouritePlayers"];
            }
            else if (playerControl.Parent.Name == "panelFavouritePlayers")
            {
                playerControl.Parent = playerControl.Parent.Parent.Controls["panelPlayers"];
            }
        }
        private void addSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in selectedControls)
            {
                var i = item as PlayerControl;
                SetParentOther(i);
            }
        }

        private void FavouritePlayersForm_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                cmsAddAll.Show(this, e.Location);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var playerContorls = panelFavouritePlayers.Controls;
            IList<string> playerNames = new List<string>();
            ISet<Player> players = new HashSet<Player>();
            foreach (var item in playerContorls)
            {
                var control = (PlayerControl)item;
                players.Add(DataFactory.Players.First(p => p.Name == control.PlayerNameLabel));

            }
            DataFactory.FavouritePlayers = players;

            var form = new RankForm();
            form.Show();

            Close();
            Dispose();

        }
    }
}
