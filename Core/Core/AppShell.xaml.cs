﻿using Core.ViewModels;
using Core.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Core
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
             
            Routing.RegisterRoute(nameof(SearchLocationViewModel), typeof(SearchLocationPage));
            Routing.RegisterRoute(nameof(LocationDetailsViewModel), typeof(LocationDetailsPage));

        }
    }
}