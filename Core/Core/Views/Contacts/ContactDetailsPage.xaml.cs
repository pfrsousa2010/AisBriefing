using Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsPage : ContactDetailsXaml
    {
        public ContactDetailsPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }
    }

    public class ContactDetailsXaml : BasePage<ContactDetailsViewModel> { }
}