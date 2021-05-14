using Core.Business;
using Core.Databases;
using Core.Models;
using Core.Services;
using Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsPage : LocationsXaml
    {
        public LocationsPage()
        {
            Initialize();            
        }

        protected override void Initialize()
        {
            InitializeComponent();
            base.Initialize();
        }

        private async void OnRemove(object sender, System.EventArgs e)
        {
            await ViewModel.OnRemove((sender as Element).BindingContext as LocationBusiness);
        }
    }

    public class LocationsXaml : BasePage<LocationsViewModel> { }
}