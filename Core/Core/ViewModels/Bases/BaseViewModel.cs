﻿using Core.Business;
using Core.Databases;
using Core.Models;
using Xamarin.Forms;

namespace Core.ViewModels
{
    public abstract class BaseViewModel : MvvmHelpers.BaseViewModel
    {

        public Interfaces.INavigation Navigation => DependencyService.Get<Interfaces.INavigation>(DependencyFetchTarget.GlobalInstance);

        public BaseViewModel()
        {
            PropertyChanged += OnPropertyChanged;
        }

        ~BaseViewModel()
        {
            PropertyChanged -= OnPropertyChanged;
        }

        protected void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        { }

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

    }

    public abstract class BaseDataViewModel<TModel, TBusiness, TDataManager> : BaseViewModel where TModel : BaseModel, new() where TBusiness : BaseBusiness<TModel>, new() where TDataManager : BaseManager<TModel>, new()
    {
        #region Fields
        private TDataManager dataManager;
        #endregion

        public TDataManager DataManager => dataManager ?? (dataManager = new TDataManager());
    }




}
