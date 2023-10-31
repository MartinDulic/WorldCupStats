using DAL.Model.Enums;
using DAL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class SettingsFileRepository : ISettingsRepository
    {
        private const char DELIMITER = ':';
        private const string SETTINGS_FILE_PATH = @"..\..\..\..\DAL\Resources\settings.txt";
        private const string SETTING_TYPE_1 = "repository";
        private const string SETTING_REPOSITORY_1 = "file";
        private const string SETTING_REPOSITORY_2 = "api";

        public void CreateSettingsIfNeeded()
        {
            if (!File.Exists(SETTINGS_FILE_PATH))
            {
                IList<string> settings = new List<string>();
                settings.Add(SETTING_TYPE_1 + SETTING_REPOSITORY_1);
                File.Create(SETTINGS_FILE_PATH);
                File.WriteAllLines(SETTINGS_FILE_PATH, settings);
            }

        }

        public AppSettings GetSettings()
        {
            string[] data = File.ReadAllLines(SETTINGS_FILE_PATH);
            AppSettings settings = new AppSettings();

                string[] parts = data[0].Split(DELIMITER);
                string repository = parts[1];
                if(repository.Trim().ToLower() == SETTING_REPOSITORY_1) {

                    settings.RepositoryType = RepoType.FILE;

                } else if (repository.Trim().ToLower() == SETTING_REPOSITORY_2)
                {
                    settings.RepositoryType = RepoType.API;
                }
                else
                {
                    throw new Exception("SettingsRepo: Invalid repo setting");
                }

            return settings;

        }

        public void UpdateSettings(AppSettings appSettings)
        {

            CreateSettingsIfNeeded();

            IList<string> settings = new List<string>
            {
                SETTING_TYPE_1 + appSettings.RepositoryType.ToString()
            };
            File.WriteAllLines(SETTINGS_FILE_PATH, settings);

        }
    }
}
