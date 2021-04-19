using Core.ViewModels;
using Core.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(ContactsViewModel), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(ContactDetailsViewModel), typeof(ContactDetailsPage));
            Routing.RegisterRoute(nameof(EditContactViewModel), typeof(EditContactPage));

            Routing.RegisterRoute(nameof(ContactGroupsViewModel), typeof(ContactGroupsPage));
            Routing.RegisterRoute(nameof(EditContactGroupViewModel), typeof(EditContactGroupPage));
            
            Routing.RegisterRoute(nameof(EditLocationViewModel), typeof(EditLocationPage));

        }
    }
}