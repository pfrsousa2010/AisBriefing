using Core.Models;
using System.ComponentModel;
using Xamarin.Forms;

namespace Core.Business
{
    public class SettingsBusiness : BaseBusiness<Settings>
    {

        public bool IsDark
        {
            get => Model.DarkTheme;
            set
            {
                Model.DarkTheme = value;
                Application.Current.UserAppTheme = value ? OSAppTheme.Dark : OSAppTheme.Light;
                OnPropertyChanged(nameof(IsDark));
            }
        }

    }
}
