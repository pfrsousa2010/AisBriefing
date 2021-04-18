using Core.Business;
using Core.Databases;
using Core.Models;

namespace Core.ViewModels
{
    public class ContactsViewModel : BaseEditDetailsCollectionViewModel<Contact, ContactBusiness, EditContactViewModel, ContactDetailsViewModel, ContactsManager>
    { }
}
