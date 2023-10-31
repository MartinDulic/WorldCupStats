using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.Model.Enums;

namespace DAL.Repositories
{
    public static class RepositoryFactory
    {
        public static ISettingsRepository GetSettingsRepository() => new SettingsFileRepository();
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

    }
}
