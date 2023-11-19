using DAL.Model;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModel
{
    internal class PlayerInfoViewModel
    {

        private IList<TeamEvent> teamEvents;
        public PlayerInfoViewModel(Player player, MatchData match) {

            foreach (var playerr in match.HomeTeamStatistics.StartingEleven)
            {
                if (player.Name == playerr.Name)
                {
                    teamEvents = match.HomeTeamEvents;
                } else
                {
                    teamEvents = match.AwayTeamEvents;
                }
            }

            playerName = player.Name;

            string imagePath;
            if (DataFactory.PlayerPitcurePaths.TryGetValue(player.Name, out string s))
            {
                imagePath = DataFactory.PlayerPitcurePaths[player.Name];
            }
            else
            {
                imagePath = "pack://application:,,,/Resources/icon1.png";
            }
            imgPath = imagePath;

            playerShirtNumber = player.ShirtNumber;
            playerPosition = player.Position;
            if ((bool)player.Captain)
            {
                playerIsCapitain = "Yes";
            }
            else
            {
                playerIsCapitain = "No";
            }
            CountGoalsForPlayer();
            CountPlayerYellowCards();
        }

        private string playerName;
        public string PlayerName { get => playerName; }
        private string imgPath;
        public string ImgPath { get => imgPath; }
        private int? playerShirtNumber;
        public int? PlayerShirtNumber { get => playerShirtNumber; }
        private string playerPosition;
        public string PlayerPosition { get => playerPosition; }
        private string playerIsCapitain;
        public string PlayerIsCapitain { get => playerIsCapitain; }

        private int playerGoalsScored;
        public int PlayerGoalsScored { get => playerGoalsScored; }

        private int playerYellowCards;
        public int PlayerYellowCards { get => playerYellowCards; }

        private void CountGoalsForPlayer()
        {
            playerGoalsScored = 0;
            foreach (var ev in teamEvents)
            {
                if (ev.TypeOfEvent == "goal" && ev.Player == PlayerName)
                {
                    playerGoalsScored++;
                }
            }
        }

        private void CountPlayerYellowCards()
        {
            playerYellowCards = 0;
            foreach (var ev in teamEvents)
            {
                if (ev.TypeOfEvent == "yellow-card" && ev.Player == PlayerName)
                {
                    playerYellowCards++;
                }
            }
        }
    }
}
