using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class ContactGroup: BaseModel
    {
        #region Fields
        string name;
        List<Contact> contacts;
        #endregion

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public List<Contact> Contacts
        {
            get => contacts;
            set => SetProperty(ref contacts, value);

        }
    }
}
