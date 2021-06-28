using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Taf : BaseModel
    {
        #region Fields
        string messageTaf;

        Location location;
        Guid locationId;
        #endregion

        public string MessageTaf
        {
            get => messageTaf;
            set => SetProperty(ref messageTaf, value);
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
