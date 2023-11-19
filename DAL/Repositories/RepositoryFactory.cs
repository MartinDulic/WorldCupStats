using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.Model.Enums;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public static class RepositoryFactory
    {
        public static ISettingsRepository GetSettingsRepository() => new AppSettingsFileRepository();
        public static IFavouriteSettingsRepository GetFavouriteSettingsRepository()
            => new FavouriteSettingsFileRepository();
        public static IDataRepository GetDataRepository()
        {
            if (GetSettingsRepository().GetSettings().RepositoryType == RepoType.FILE)
            {
                return new FileDataRepository();
            }
            return new ApiDataRepository();
        }
        public static IDataRepository GetFileRepository() => new FileDataRepository();
        public static IDataRepository GetApiRepository() => new ApiDataRepository();
        public static IPlayerPictureRepository GetPlayerPictureRepository() => new PlayerPictureFileRepo();
    }
}
