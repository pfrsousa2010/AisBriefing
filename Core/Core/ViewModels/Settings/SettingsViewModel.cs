using Core.Business;
using Core.Databases.Manager;
using Core.Models;

namespace Core.ViewModels
{
    public class SettingsViewModel : BaseEditItemViewModel<Settings, SettingsBusiness, SettingsManager>
    {
        public override void OnAppearing()
        {
            base.OnAppearing();
            Business = new SettingsBusiness { Model = DataManager.GetSettings() };
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            DataManager.SaveAsync(Business.Model);
        }
    }
}
