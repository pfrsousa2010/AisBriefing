using System;

namespace Core.Models
{
    public class Contact : BaseModel
    {
        #region Fields
        string name;
        string phone;
        string email;
        string note;
        
        ContactGroup group;
        Guid groupId;
        #endregion

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Note
        {
            get => note;
            set => SetProperty(ref note, value);
        }

        public ContactGroup Group
        {
            get => group;
            set => SetProperty(ref group, value);
        }

        public Guid GroupId
        {
            get => groupId;
            set => SetProperty(ref groupId, value);
        }
    }
}
