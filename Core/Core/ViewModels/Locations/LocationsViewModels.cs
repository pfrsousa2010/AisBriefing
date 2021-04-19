using Core.Business;
using Core.Databases;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class LocationsViewModels : BaseEditCollectionViewModel<Location, LocationBusiness, EditLocationViewModel, BaseManager<Location>>
    {
    }
}
