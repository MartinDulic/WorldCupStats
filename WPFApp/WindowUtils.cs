using DAL.Repositories;
using DAL.Model;
using System;
using DAL.Model.Enums;
using System.Windows;

namespace WPFApp
{
    internal class WindowUtils
    {
        internal static void SetDesiredResolution(Window mainWindow)
        {
            switch (DataFactory.AppSettings.Resolution)
            {
                case Resolution.r1920x1080:
                    mainWindow.Width = 1920;
                    mainWindow.Height = 1080;
                    break;

                case Resolution.r1600x1200:
                    mainWindow.Width = 1600;
                    mainWindow.Height = 1200;
                    break;

                case Resolution.r720x480:
                    mainWindow.Width = 720;
                    mainWindow.Height = 480;
                    break;

                default:
                    // Set default size or handle unknown resolution
                    mainWindow.Width = 720;
                    mainWindow.Height = 480;
                    break;
            }
        }

    }
}