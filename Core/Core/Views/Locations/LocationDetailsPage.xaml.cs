using Core.Databases;
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

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            if(labelTypeOpr.Text == "VFR IFR")
            {
                DisplayAlert("Tipo de Operação", "Operação VFR DIURNA e NOTURNA e IFR DIURNA e NOTURNA.", "OK");
            }
            else if(labelTypeOpr.Text == "IFR")
            {
                DisplayAlert("Tipo de Operação", "Operação VFR DIURNA e IFR DIURNA e NOTURNA.", "OK");
            }
            else if (labelTypeOpr.Text == "VFR")
            {
                DisplayAlert("Tipo de Operação", "Operação VFR DIURNA e NOTURNA.", "OK");
            }
            else if (labelTypeOpr.Text == "IFR DIURNA")
            {
                DisplayAlert("Tipo de Operação", "Operação VFR DIURNA e IFR DIURNA.", "OK");
            }
            else if (labelTypeOpr.Text == "VFR IFR DIURNA")
            {
                DisplayAlert("Tipo de Operação", "Operação VFR DIURNA e NOTURNA e IFR DIURNA.", "OK");
            }
            else
            {
                return;
            }

        }
    }

    public class LocationDetailsXaml : BasePage<LocationDetailsViewModel> { }
    
}