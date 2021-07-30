using Core.Business;
using Core.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class SearchLocationViewModel : BaseViewModel
    {
        #region Fields
        string text;
        Location selectedItem;
        AsyncCommand<Location> callBackAsync;
        #endregion

        public ObservableRangeCollection<Location> Items { get; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public ICommand SearchCommand { get; }
        public ICommand SelectedCommand { get; }

        public AsyncCommand<Location> CallBackAsync
        {
            get => callBackAsync;
            set => SetProperty(ref callBackAsync, value);
        }

        public Location SelectedItem 
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        public SearchLocationViewModel()
        {
            SearchCommand = new AsyncCommand(OnSearch);
            SelectedCommand = new AsyncCommand(OnSelect);
            Items = new ObservableRangeCollection<Location>();
        }

        private async Task OnSelect()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                await Task.Delay(100);
                await CallBackAsync.ExecuteAsync(SelectedItem);
                await Navigation.GoToBackAsync();
                IsBusy = false;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                IsBusy = false;
            }
        }

        private async Task OnSearch()
        {
            var searchLocations = await Task.Run(() =>
            {
                IsBusy = true;

                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Views.LocationsPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("Core.Files.locations.json");

                using (var reader = new StreamReader(stream))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Dictionary<string, Location>>(json).Select(x => x.Value);
                }
            });
            
            if (Text.Trim().Length >= 3)
            {
                Items.ReplaceRange(searchLocations
                .Where(s => 
                s.Country == "BR" &&
                (s.City.ToUpper().Contains(Text.ToUpper().Trim()) ||
                s.Name.ToUpper().Contains(Text.ToUpper().Trim()) ||
                s.IdIcao == Text.ToUpper().Trim())
                ).Take(100));
            }

            IsBusy = false;
        }
    }
}
