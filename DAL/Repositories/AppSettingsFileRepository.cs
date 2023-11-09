using DAL.Model.Enums;
using DAL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class AppSettingsFileRepository : ISettingsRepository
    {
        private const char DELIMITER = ':';
        private const string SETTINGS_FILE_PATH = @"..\..\..\..\DAL\Resources\settings.txt";
        private const string SETTING_TYPE_1 = "repository";
        private const string SETTING_REPOSITORY_1 = "file";
        private const string SETTING_REPOSITORY_2 = "api";
        private const string SETTING_TYPE_2 = "lang";
        private const string SETTING_REPOSITORY_3 = "croatian";
        private const string SETTING_REPOSITORY_4 = "english";
        private const string SETTING_TYPE_3 = "championship";
        private const string SETTING_REPOSITORY_5 = "men";
        private const string SETTING_REPOSITORY_6 = "woman";

        public bool CreateSettingsIfNeeded()
        {
            if (!File.Exists(SETTINGS_FILE_PATH))
            {
                IList<string> settings = new List<string>
                {
                    SETTING_TYPE_1 + DELIMITER + SETTING_REPOSITORY_1,
                    SETTING_TYPE_2 + DELIMITER + SETTING_REPOSITORY_3,
                    SETTING_TYPE_3 + DELIMITER + SETTING_REPOSITORY_5,
                };
                
                File.WriteAllLines(SETTINGS_FILE_PATH, settings);
                return true;
            }

            return false;
        }

        public AppSettings GetSettings()
        {
            CreateSettingsIfNeeded();
            string[] data = File.ReadAllLines(SETTINGS_FILE_PATH);
            AppSettings settings = new AppSettings
            {
                RepositoryType = ParseRepositoryType(data[0]),
                Language = ParseLanguage(data[1]),
                SelectedChampionship = ParseSelectedChampionship(data[2])
            };

            return settings;
        }

        private RepoType ParseRepositoryType(string line)
        {
            string value = GetValueFromLine(line);
            return value switch
            {
                SETTING_REPOSITORY_1 => RepoType.FILE,
                SETTING_REPOSITORY_2 => RepoType.API,
                _ => throw new Exception("SettingsRepo: Invalid repo setting")
            };
        }

        private Language ParseLanguage(string line)
        {
            string value = GetValueFromLine(line);
            return value switch
            {
                SETTING_REPOSITORY_3 => Language.CROATIAN,
                SETTING_REPOSITORY_4 => Language.ENGLISH,
                _ => throw new Exception("SettingsRepo: Invalid language setting")
            };
        }

        private SelectedChampionship ParseSelectedChampionship(string line)
        {
            string value = GetValueFromLine(line);
            return value switch
            {
                SETTING_REPOSITORY_5 => SelectedChampionship.MEN,
                SETTING_REPOSITORY_6 => SelectedChampionship.WOMAN,
                _ => throw new Exception("SettingsRepo: Invalid championship setting")
            };
        }

        private string GetValueFromLine(string line)
        {
            string[] parts = line.Split(DELIMITER);
            return parts[1].Trim().ToLower();
        }


        public void UpdateSettings(AppSettings appSettings)
        {

            CreateSettingsIfNeeded();

            IList<string> settings = new List<string>
            {
                SETTING_TYPE_1 + DELIMITER + appSettings.RepositoryType.ToString().ToLower(),
                SETTING_TYPE_2 + DELIMITER + appSettings.Language.ToString().ToLower(),
                SETTING_TYPE_3 + DELIMITER + appSettings.SelectedChampionship.ToString().ToLower()

            };
            File.WriteAllLines(SETTINGS_FILE_PATH, settings);

        }
    }
}
