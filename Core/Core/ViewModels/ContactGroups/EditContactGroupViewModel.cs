using Core.Business;
using Core.Databases;
using Core.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core.ViewModels
{
    public class EditContactGroupViewModel : BaseEditItemViewModel<ContactGroup, ContactGroupBusiness, BaseManager<ContactGroup>>
    { }
}
