using DAL.Settings;

namespace DAL.Repositories.Interfaces
{
    public interface IFavouriteSettingsRepository
    {
        bool CreateSettingsIfNeeded();
        FavouriteSettings GetSettings();
        void UpdateSettings(FavouriteSettings appSettings);
    }
}