using Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditLocationPage : EditLocationXaml
    {
        public EditLocationPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }
    }

    public class EditLocationXaml : BasePage<EditLocationViewModel> { }
}