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
    }

    public class EditSettingsXaml : BasePage<SettingsViewModel> { }
}