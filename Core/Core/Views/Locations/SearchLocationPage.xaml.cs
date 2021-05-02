using Core.Business;
using Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchLocationPage : SearchLocationXaml
    {
        public SearchLocationPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            base.Initialize();
            InitializeComponent();
        }


    }

    public class SearchLocationXaml : BasePage<SearchLocationViewModel> { }
}