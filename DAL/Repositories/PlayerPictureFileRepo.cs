using DAL.Model;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class PlayerPictureFileRepo : IPlayerPictureRepository
    {
        private const string SETTINGS_FILE_PATH = @"..\..\..\..\DAL\Resources\pictureSettings.txt";
        private const string DELIMITER = ";";

        public bool CreateSettingsIfNeeded()
        {
            if (!File.Exists(SETTINGS_FILE_PATH))
            {
                File.Create(SETTINGS_FILE_PATH);
                return true;
            }
            return false;
        }
        public IDictionary<string, string> GetAllPicturePaths()
        {
            CreateSettingsIfNeeded();
            string[] data = File.ReadAllLines(SETTINGS_FILE_PATH);
            IDictionary<string,string> result = new Dictionary<string,string>();
            for (int i = 0; i < data.Length; i++) {

                string[] strings = data[i].Split(DELIMITER);
                string playerName = strings[0];
                string picturePath = strings[1];
                result.Add(playerName, picturePath);
            }
            return result;
        }

        public void SaveAllPictures(IDictionary<string, string> picturePaths)
        {
            CreateSettingsIfNeeded();
            IList<string> pictures = new List<string>();
            foreach (var picturePath in picturePaths)
            {
                string val = picturePath.Key + DELIMITER + picturePath.Value;
                pictures.Add(val);
                
            }
            File.WriteAllLines(SETTINGS_FILE_PATH, pictures);
        }
    }
}
