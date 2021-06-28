using Core.Business;
using Core.Databases;
using Core.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.ViewModels
{
    public class LocationDetailsViewModel : BaseItemDetailsViewModel<Location, LocationBusiness, LocationsManager>
    {

        public ObservableRangeCollection<NotamBusiness> NotamsBusiness { get; }
        public ObservableRangeCollection<AipSuplementBusiness> AipSuplementBusiness { get; }


        public LocationDetailsViewModel()
        {
            NotamsBusiness = new ObservableRangeCollection<NotamBusiness>();                     
            AipSuplementBusiness = new ObservableRangeCollection<AipSuplementBusiness>();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Business))
            {

                foreach (var notam in Business.Model.Notams)
                {
                    NotamsBusiness.Add(new NotamBusiness
                    {
                        Model = notam
                    });
                }

                foreach (var aipSuplement in Business.Model.AipSuplements)
                {
                    AipSuplementBusiness.Add(new AipSuplementBusiness
                    {
                        Model = aipSuplement
                    });
                }

            }

        }
    }
}
