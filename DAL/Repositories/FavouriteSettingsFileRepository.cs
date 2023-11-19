using DAL.Model;
using DAL.Repositories.Interfaces;
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
        
        private const string SETTINGS_FILE_PATH = @"..\..\..\..\DAL\Resources\settingsFavourite.txt";
        private const string SETTING_TYPE_1 = "favouriteTeam";
        private const string SETTING_TYPE_2 = "favouritePlayers";

        public bool CreateSettingsIfNeeded()
        {
            if (!File.Exists(SETTINGS_FILE_PATH))
            {
                
                IList<string> settings = new List<string>
                {
                    SETTING_TYPE_1 + Utils.DELIMITER + "null",
                    SETTING_TYPE_2 + Utils.DELIMITER + Player.DEAFULT_NAME + Utils.LIST_DELIMITER
                    + Player.DEAFULT_NAME + Utils.LIST_DELIMITER + Player.DEAFULT_NAME

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
            string[] values = Utils.GetValuesFromLine(line);
            ISet<Player> players = DataFactory.Players;
            
            foreach (string s in values) {
            
                Player player = players.FirstOrDefault(p => p.Name == s);
                /*if (player is null)
                {
                    player = new Player();
                    player.Name = Player.DEAFULT_NAME;
                }*/

                favouritePlayers.Add(player);

            }
            return favouritePlayers;
        }

        private CountryTeam ParseFavouriteTeam(string line)
        {
            string value = Utils.GetValueFromLine(line);

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
                    playersString += Utils.LIST_DELIMITER;
                }

            }
            IList<string> settings = new List<string>
            {
                SETTING_TYPE_1 + Utils.DELIMITER + favouriteSettings.FavouriteTeam.CountryName,
                SETTING_TYPE_2 + Utils.DELIMITER + playersString
            };
            File.WriteAllLines(SETTINGS_FILE_PATH, settings);
        }



    }
}
