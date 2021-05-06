using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Notam : BaseModel
    {
        #region Fields
        string startDate;
        string endDate;
        string message;
        
        Location location;
        Guid locationId;
        #endregion

        public string StartDate
        {
            get => startDate;
            set => SetProperty(ref startDate, value);
        }

        public string EndDate
        {
            get => endDate;
            set => SetProperty(ref endDate, value);
        }

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
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
