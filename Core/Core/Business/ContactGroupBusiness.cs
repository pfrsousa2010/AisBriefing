using Core.Models;
using Core.Validators;
using System.Linq;

namespace Core.Business
{
    public class ContactGroupBusiness : BaseBusiness<ContactGroup>
    {
        public string NameValidation => Erros?.Where(s => s.PropertyName == nameof(Model.Name)).FirstOrDefault()?.ErrorMessage;
        
        public ContactGroupBusiness()
        {
            Validator = new ContactGroupValidator();
        }

        public override void Validate()
        {
            base.Validate();
            OnPropertyChanged(nameof(NameValidation));
        }
    }
}
