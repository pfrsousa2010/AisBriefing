using Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactGroupPage : EditContactGroupXaml
    {
        public EditContactGroupPage()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }
    }

    public class EditContactGroupXaml : BasePage<EditContactGroupViewModel> { }
}