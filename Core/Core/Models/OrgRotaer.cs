using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class OrgRotaer: BaseModel
    {
        #region Field
        string name;
        string type;

        Location location;
        Guid locationId;
        #endregion

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }
        
        public Location Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }
        
        public Guid LocationId
        {
            get => locationId;
            set => SetProperty(ref locationId, value);
        }
    }
}
