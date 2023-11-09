using DAL.Settings;

namespace DAL.Repositories
{
    public interface IFavouriteSettingsRepository
    {
        bool CreateSettingsIfNeeded();
        FavouriteSettings GetSettings();
        void UpdateSettings(FavouriteSettings appSettings);
    }
}