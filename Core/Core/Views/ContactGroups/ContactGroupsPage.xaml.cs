using Core.Business;
using Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactGroupsPage : ContactGroupsXaml
    {
        public ContactGroupsPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }

        private async void OnRemove(object sender, System.EventArgs e)
        {
            await ViewModel.OnRemove((sender as Element).BindingContext as ContactGroupBusiness);
        }
    }

    public class ContactGroupsXaml : BasePage<ContactGroupsViewModel> { }
}