using Core.Models;
using Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Business
{
    public class LocationBusiness : BaseBusiness<Location>
    {
        public string NameValidation => Erros?.Where(s => s.PropertyName == nameof(Model.Name)).FirstOrDefault()?.ErrorMessage;
        public string IdIcaoValidation => Erros?.Where(s => s.PropertyName == nameof(Model.IdIcao)).FirstOrDefault()?.ErrorMessage;
    
        public LocationBusiness()
        {
            Validator = new LocationValidator();
        }

        public override void Validate()
        {
            base.Validate();
            OnPropertyChanged(nameof(NameValidation));
            OnPropertyChanged(nameof(IdIcaoValidation));


        }
    }
}
