using Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditSettingsPage : EditSettingsXaml
    {
        public EditSettingsPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }

        private void about_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("About the app", "Weather informations: \nAviation Weather Center \n\nAirport Informations: \nAIS WEB DECEA \n\nDeveloped by Paulo Felipe Sousa \n\nE-mail: aisbriefing.app@gmail.com", "OK");
        }
    }

    public class EditSettingsXaml : BasePage<SettingsViewModel> { }
}