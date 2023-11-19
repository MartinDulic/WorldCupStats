using DAL;
using DAL.Model;
using DAL.Model.Enums;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF.ViewModel
{
    internal class PlayerControlViewModel
    {
        public PlayerControlViewModel(Player player) {

            playerName = player.Name;

            string imagePath;
            if (DataFactory.PlayerPitcurePaths.TryGetValue(player.Name, out string s))
            {
                imagePath = DataFactory.PlayerPitcurePaths[player.Name];
            } else
            {
                imagePath = "pack://application:,,,/Resources/icon1.png";
            }
            playerImage = imagePath;

            
            switch (DataFactory.AppSettings.Resolution)
            {
                case Resolution.r720x480:
                    pictureDimension = 50;
                    controlDimension = 70;
                    fontSize = 5;
                    margins = "5 5 5 5";
                    break;
                case Resolution.r1600x1200:
                    pictureDimension = 130;
                    controlDimension = 157;
                    fontSize = 11;
                    margins = "7 7 7 7";
                    break;
                case Resolution.r1920x1080:
                    pictureDimension = 145;
                    controlDimension = 160;
                    fontSize = 15;
                    margins = "7 7 7 7";
                    break;
                default:
                    pictureDimension = 145;
                    controlDimension = 160;
                    fontSize = 15;
                    margins = "7 7 7 7";
                    break;
            }

        }

        private string playerName;
        public string PlayerName { get => playerName; }

        private string playerImage;
        public string PlayerImage { get => playerImage; }

        private int pictureDimension;
        public int PictureDimension { get => pictureDimension; }

        private int controlDimension;
        public int ControlDimension { get => controlDimension; }

        private int fontSize;
        public int FontSize { get => fontSize; }

        private string margins;
        public string Margins { get => margins; }

    }
}
