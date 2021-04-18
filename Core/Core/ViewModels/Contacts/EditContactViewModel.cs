using Core.Business;
using Core.Databases;
using Core.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class EditContactViewModel : BaseEditItemViewModel<Contact, ContactBusiness, ContactsManager>
    {
        readonly BaseManager<ContactGroup> contactGroupsManager;
        public ObservableRangeCollection<ContactGroup> ContactGroups { get; }
       
        public EditContactViewModel()
        {
            contactGroupsManager = new BaseManager<ContactGroup>();
            ContactGroups = new ObservableRangeCollection<ContactGroup>();
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();

            if (ContactGroups.Count == 0)
                await OnLoadContactGroups();
        }

        public async Task OnLoadContactGroups()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                await Task.Delay(100);

                if (ContactGroups.Count == 0)
                {
                    var models = contactGroupsManager.GetAll();
                    ContactGroups.ReplaceRange(models);
                }
                else
                {
                    ContactGroups.Clear();
                }

                IsBusy = false;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                IsBusy = false;
            }
        }
    }
}
