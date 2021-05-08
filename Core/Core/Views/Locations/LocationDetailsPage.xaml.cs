using Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationDetailsPage : LocationDetailsXaml
    {
        public LocationDetailsPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }
    }

    public class LocationDetailsXaml : BasePage<LocationDetailsViewModel> { }
}