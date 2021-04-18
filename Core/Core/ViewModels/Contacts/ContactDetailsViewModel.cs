using Core.Business;
using Core.Databases;
using Core.Models;

namespace Core.ViewModels
{
    public class ContactDetailsViewModel : BaseItemDetailsViewModel<Contact, ContactBusiness, ContactsManager>
    { }
}
