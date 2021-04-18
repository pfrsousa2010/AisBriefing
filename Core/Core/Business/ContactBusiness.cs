using Core.Models;
using Core.Validators;
using MvvmHelpers.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Core.Business
{
    public class ContactBusiness : BaseBusiness<Contact>
    {
        public string NameValidation => Erros?.Where(s => s.PropertyName == nameof(Model.Name)).FirstOrDefault()?.ErrorMessage;
       
        public string PhoneValidation => Erros?.Where(s => s.PropertyName == nameof(Model.Phone)).FirstOrDefault()?.ErrorMessage;

        public string EmailValidation => Erros?.Where(s => s.PropertyName == nameof(Model.Email)).FirstOrDefault()?.ErrorMessage;

        public string GroupValidation => Erros?.Where(s => s.PropertyName == nameof(Model.Group)).FirstOrDefault()?.ErrorMessage;

        public ICommand OpenWhatAppCommand { get; }

        public ContactBusiness()
        {
            Validator = new ContactValidator();
            OpenWhatAppCommand = new AsyncCommand(OnOpenWhatApp);
        }

        private async Task OnOpenWhatApp()
        {
            var uri = new Uri($"https://wa.me/55{Model.Phone}");
            await Xamarin.Essentials.Browser.OpenAsync(uri, Xamarin.Essentials.BrowserLaunchMode.SystemPreferred);
        }

        public override void Validate()
        {
            base.Validate();
            OnPropertyChanged(nameof(NameValidation));
            OnPropertyChanged(nameof(PhoneValidation));
            OnPropertyChanged(nameof(EmailValidation));
            OnPropertyChanged(nameof(GroupValidation));
        }


    }
}
