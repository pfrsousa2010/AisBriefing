using Core.Business;
using Core.Databases;
using Core.Models;

namespace Core.ViewModels
{
    public class ContactGroupsViewModel : BaseEditCollectionViewModel<ContactGroup, ContactGroupBusiness, EditContactGroupViewModel,  BaseManager<ContactGroup>>
    { }
}
