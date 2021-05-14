using Core.Business;
using Core.Databases;
using Core.Models;
using Core.Services;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class LocationsViewModel : BaseDetailsCollectionViewModel<Location, LocationBusiness,LocationDetailsViewModel, LocationsManager>
    {
        public ICommand SearchCommand { get; }
        public AsyncCommand<Location> AddLocationCommand { get; }

        protected override async Task OnLoad()
        {
            try
            {
                if (IsBusy)
                    return;


                IsBusy = true;
                await Task.Delay(100);

                if (Items.Count == 0)
                {
                    var models =  DataManager.GetAll();

                    if (models.Count() > 0)
                    {
                        var newItems = new List<LocationBusiness>();

                        foreach (var model in models)
                            newItems.Add(new LocationBusiness { Model = model });

                        Items.ReplaceRange(newItems);
                    }
                }
                else
                {
                    Items.Clear();
                }

                IsBusy = false;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                IsBusy = false;
            }
        }

        public LocationsViewModel()
        {
            SearchCommand = new AsyncCommand(OnSearch);
            AddLocationCommand = new AsyncCommand<Location>(OnAddLocation);            
        }


        private async Task OnAddLocation(Location location)
        {
            if (Items.Any(l => l.Model == location))
                return;

            await DataManager.SaveAsync(location);
            var businessLocation = new LocationBusiness { Model = location};
            Items.Add(businessLocation);
        }

        private async Task OnSearch()
        {
            var viewModel = await Navigation.GoToAsync<SearchLocationViewModel>();
            viewModel.CallBackAsync = AddLocationCommand;
        }
    }
}
