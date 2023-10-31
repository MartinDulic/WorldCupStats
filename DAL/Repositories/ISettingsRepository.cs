using DAL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ISettingsRepository
    {

        public AppSettings GetSettings();
        public void UpdateSettings(AppSettings appSettings);
        public void CreateSettingsIfNeeded();

    }
}
