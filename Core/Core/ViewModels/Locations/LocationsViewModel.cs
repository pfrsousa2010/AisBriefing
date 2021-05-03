using Core.Business;
using Core.Databases;
using Core.Models;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class LocationsViewModel : BaseCollectionViewModel<Location, LocationBusiness, BaseManager<Location>>
    {
        public ICommand SearchCommand { get; }
        public ICommand AddLocationCommand { get; }
        public ICommand SelectedLocationCommand { get; }


        public LocationsViewModel()
        {
            SearchCommand = new AsyncCommand(OnSearch);
            AddLocationCommand = new Command<Location>(OnAddLocation);            
        }

        private void OnAddLocation(Location location)
        {
            var businessLocation = new LocationBusiness { Model = location};
            Items.Add(businessLocation);
            DataManager.Save(location);
            
        }

        private async Task OnSearch()
        {
            var viewModel = await Navigation.GoToAsync<SearchLocationViewModel>();
            viewModel.CallBackCommand = AddLocationCommand;
        }
    }
}
