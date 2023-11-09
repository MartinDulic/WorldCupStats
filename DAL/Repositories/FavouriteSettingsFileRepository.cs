using DAL.Model;
using DAL.Settings;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class FavouriteSettingsFileRepository : IFavouriteSettingsRepository
    {
        private const char DELIMITER = ':';
        private const char LIST_DELIMITER = ',';
        private const string SETTINGS_FILE_PATH = @"..\..\..\..\DAL\Resources\settingsFavourite.txt";
        private const string SETTING_TYPE_1 = "favouriteTeam";
        private const string SETTING_TYPE_2 = "favouritePlayers";

        public bool CreateSettingsIfNeeded()
        {
            if (!File.Exists(SETTINGS_FILE_PATH))
            {
                IList<string> settings = new List<string>
                {
                    SETTING_TYPE_1 + DELIMITER + "null",
                    SETTING_TYPE_2 + DELIMITER + "null,null,null"

                };
                File.WriteAllLines(SETTINGS_FILE_PATH, settings);
                return true;
            }
            return false;
        }

        public FavouriteSettings GetSettings()
        {
            CreateSettingsIfNeeded();
            string[] data = File.ReadAllLines(SETTINGS_FILE_PATH);
            var settings = new FavouriteSettings
            {
                FavouriteTeam = ParseFavouriteTeam(data[0]),
                FavouritePlayers = ParseFavouritePlayers(data[1])
            };

            return settings;
        }

        private IList<Player> ParseFavouritePlayers(string line)
        {
            var favouritePlayers = new List<Player>();
            string[] values = GetValuesFromLine(line);
            ISet<MatchData> matches = RepositoryFactory.GetDataRepository().GetAllManMatchData();
            ISet<TeamStatistics> stats = new HashSet<TeamStatistics>();
            ISet<Player> players = new HashSet<Player>();
            foreach (MatchData matchData in matches)
            {
                stats.Add(matchData.AwayTeamStatistics);
                stats.Add(matchData.HomeTeamStatistics);

            }
            foreach (var stat in stats)
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
            foreach (string s in values) {
            
                Player player = players.FirstOrDefault(p => p.Name == s);
                favouritePlayers.Add(player);

            }
            return favouritePlayers;
        }

        private CountryTeam ParseFavouriteTeam(string line)
        {
            string value = GetValueFromLine(line);

            var team = RepositoryFactory.GetDataRepository().GetAllMenCountryTeamData().FirstOrDefault(t => t.CountryName == value);
            return team;
        }

        public void UpdateSettings(FavouriteSettings favouriteSettings)
        {
            CreateSettingsIfNeeded();
            string playersString = "";
            for (int i = 0; i < favouriteSettings.FavouritePlayers.Count; i++)
            {
                playersString += favouriteSettings.FavouritePlayers.ElementAt(i);
                if(i!= favouriteSettings.FavouritePlayers.Count - 1)
                {
                    playersString += LIST_DELIMITER;
                }

            }
            IList<string> settings = new List<string>
            {
                SETTING_TYPE_1 + DELIMITER + favouriteSettings.FavouriteTeam.ToString(),
                SETTING_TYPE_2 + DELIMITER + playersString
            };
            File.WriteAllLines(SETTINGS_FILE_PATH, settings);
        }

        private string GetValueFromLine(string line)
        {
            string[] parts = line.Split(DELIMITER);
            return parts[1].Trim();
        }
        private string[] GetValuesFromLine(string line)
        {
            string[] parts = line.Split(DELIMITER);
            string[] values = parts[1].Split(LIST_DELIMITER);
            return values;
        }
    }
}
