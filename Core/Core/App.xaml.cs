using Core.Databases.Manager;
using Core.Helpers;
using Core.Navigations;
using Xamarin.Forms;

namespace Core
{
    /// <summary>
    /// Multilingual App Toolkit
    /// Windows Credentials : Generic Credential
    /// address : Multilingual/MicrosoftTranslator
    /// user : Multilingual App Toolkit
    /// Key : 88976015a9e4492790b4bb53eed5b2de
    /// </summary>
    /// 
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        public App(string dbPath)
        {
            // dependency injection
            DependencyService.Register<Navigation>();
            
            Constants.DatabasePath = dbPath;
            var settingsManager = new SettingsManager();
            var settings = settingsManager.GetSettings();

            UserAppTheme = settings.DarkTheme ? OSAppTheme.Dark : OSAppTheme.Light;

            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
