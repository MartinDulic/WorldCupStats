using DAL.Model;
using DAL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public static class DataFactory
    {

        public static string PLAYER_PICTURES_PATH = "..\\..\\..\\..\\DAL\\Resources\\Images\\icon";
        public static string PLAYER_PICTURES_EXTENSION = ".png";
        private static IDataRepository dataRepository = RepositoryFactory.GetDataRepository();
        private static ISettingsRepository settingsRepository = RepositoryFactory.GetSettingsRepository();
        private static IFavouriteSettingsRepository favouriteSettingsRepository = 
            RepositoryFactory.GetFavouriteSettingsRepository();
        private static IPlayerPictureRepository pictureRepository = RepositoryFactory.GetPlayerPictureRepository();
        public static ISet<CountryTeam> CountryTeams { get => dataRepository.GetAllMenCountryTeamData(); } 
        public static ISet<MatchData> Matches { get => dataRepository.GetAllManMatchData(); } 
        public static ISet<TeamStatistics> Statistics { get => GetStatistics(); }
        public static ISet<TeamEvent> TeamEvents { get => GetTeamEvents(); }

        public static ISet<Player>? Players { get => ParsePlayers(); }
        public static ISet<Player> FavouritePlayers { get => 
                favouriteSettingsRepository.GetSettings().FavouritePlayers.ToHashSet();
            set
            {
                var settings = favouriteSettingsRepository.GetSettings();
                settings.FavouritePlayers = value.ToList();
                favouriteSettingsRepository.UpdateSettings(settings);
            }
        }
        
        public static ISet<TeamEvent> Events
        {
            get {
                ISet<TeamEvent> events = new HashSet<TeamEvent>();
                Matches.ToList().ForEach(m => m.HomeTeamEvents.ForEach(te => events.Add(te)));
                Matches.ToList().ForEach(m => m.AwayTeamEvents.ForEach(te => events.Add(te)));
                return events;
            }
        }


        private static IDictionary<string, PlayerRankingData> GetPlayerGoalAndYellowCardData()
        {
            IDictionary<string, PlayerRankingData> playersData = new Dictionary<string, PlayerRankingData>();
            foreach (var item in Events)
            {

                if (item.TypeOfEvent == "goal")
                {
                    if (!playersData.ContainsKey(item.Player))
                    {
                        var playerData = new PlayerRankingData();
                        playerData.Goals = 1;
                        playerData.YellowCards = 0;
                        playerData.Occurances = 0;
                        playersData.Add(item.Player, playerData);
                    }
                    else
                    {
                        var data = playersData[item.Player];
                        data.Goals++;
                        playersData[item.Player] = data;
                    }
                }
                else if (item.TypeOfEvent == "yellow-card")
                {
                    if (!playersData.ContainsKey(item.Player))
                    {
                        var playerData = new PlayerRankingData();
                        playerData.Goals = 0;
                        playerData.YellowCards = 1;
                        playerData.Occurances = 0;
                        playersData.Add(item.Player, playerData);
                    }
                    else
                    {
                        var data = playersData[item.Player];
                        data.YellowCards++;
                        playersData[item.Player] = data;
                    }

                }

            }
            return playersData;
        }

        public static ISet<MatchData> MatchDataForSelectedCountry
        {
            get => dataRepository.GetManMatchDataByCountry(favouriteSettingsRepository.GetSettings().FavouriteTeam.FifaCode);
        }
        public static IDictionary<string, PlayerRankingData> PlayerDataForSelectedCountry {
            get
            {
                IDictionary<string, PlayerRankingData> allPlayersData = GetAllPlayerRankingData();
                IDictionary<string, PlayerRankingData> nededPlayersData = new Dictionary<string, PlayerRankingData>();
                string choosenTeamName = favouriteSettingsRepository.GetSettings().FavouriteTeam.CountryName;
                ISet<string> countryTeamPlayerNames = new HashSet<string>();

                foreach ( var match in Matches)
                {
                    if (match.HomeTeamCountry == choosenTeamName)
                    {

                        foreach (var player in match.HomeTeamStatistics.StartingEleven)
                        {
                            countryTeamPlayerNames.Add(player.Name);
                        }
                        foreach (var player in match.HomeTeamStatistics.Substitutes)
                        {
                            countryTeamPlayerNames.Add(player.Name);
                        }
                    } else if (match.AwayTeamCountry == choosenTeamName)
                    {

                        foreach (var player in match.AwayTeamStatistics.StartingEleven)
                        {
                            countryTeamPlayerNames.Add(player.Name);
                        }
                        foreach (var player in match.AwayTeamStatistics.Substitutes)
                        {
                            countryTeamPlayerNames.Add(player.Name);
                        }
                    }
                }

                
                foreach ( var playerName in countryTeamPlayerNames ) {

                    PlayerRankingData data;
                    if (allPlayersData.TryGetValue(playerName, out data))
                    {
                        if (!nededPlayersData.ContainsKey(playerName))
                        {
                            nededPlayersData.Add(playerName, data);
                        }

                    }

                }

                return nededPlayersData;
            }
        }

        private static IDictionary<string, PlayerRankingData> GetAllPlayerRankingData()
        {
            IDictionary<string, PlayerRankingData> playersData = GetPlayerGoalAndYellowCardData();

            foreach (var stat in Statistics)
            {

                foreach (var player in stat.StartingEleven)
                {
                    if (!playersData.ContainsKey(player.Name))
                    {
                        var playerData = new PlayerRankingData();
                        playerData.Goals = 0;
                        playerData.YellowCards = 0;
                        playerData.Occurances = 1;
                        playersData.Add(player.Name, playerData);
                    }
                    else
                    {
                        var data = playersData[player.Name];
                        data.Occurances++;
                        playersData[player.Name] = data;
                    }

                }

            }

            foreach (var ev in TeamEvents)
            {
                if (ev.TypeOfEvent == "substitution-in")
                {
                    if (!playersData.ContainsKey(ev.Player))
                    {
                        var playerData = new PlayerRankingData();
                        playerData.Goals = 0;
                        playerData.YellowCards = 0;
                        playerData.Occurances = 1;
                        playersData.Add(ev.Player, playerData);
                    }
                    else
                    {
                        var data = playersData[ev.Player];
                        data.Occurances++;
                        playersData[ev.Player] = data;
                    }

                }
            }

            return playersData;
        }

        public static IDictionary<string,string> PlayerPitcurePaths
        {
            get => pictureRepository.GetAllPicturePaths();
            set => pictureRepository.SaveAllPictures(value);
        }

        public static AppSettings AppSettings {
            get { return settingsRepository.GetSettings(); }
            set { settingsRepository.UpdateSettings(value); }
        }
        public static FavouriteSettings FavouriteSettings
        {
            get { return favouriteSettingsRepository.GetSettings(); }
            set { favouriteSettingsRepository.UpdateSettings(value); }
        }

        private static ISet<Player> ParsePlayers()
        {
            ISet<Player> players = new HashSet<Player>();
            foreach (var stat in Statistics)
            {
                foreach (var p in stat.StartingEleven)
                {
                    players.Add(p);
                }
                foreach (var p in stat.Substitutes)
                {
                    players.Add(p);
                }
            }
            
            return players;
        }


        private static ISet<TeamStatistics> GetStatistics()
        {
            var stats = new HashSet<TeamStatistics>();
            foreach (MatchData matchData in Matches)
            {
                stats.Add(matchData.AwayTeamStatistics);
                stats.Add(matchData.HomeTeamStatistics);

            }
            return stats;
        }
        private static ISet<TeamEvent> GetTeamEvents()
        {
            var events = new List<TeamEvent>();

            foreach (var match in Matches)
            {
                events.AddRange(match.HomeTeamEvents);
                events.AddRange(match.AwayTeamEvents);
            }
            return events.ToHashSet();
        }
    }
}
