using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Notam : BaseModel
    {
        #region Fields
        string notamId;
        string startDate;
        string endDate;
        string message;
        Location location;
        #endregion

        public string NotamId
        {
            get => notamId;
            set => SetProperty(ref notamId, value);
        }
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

    }
}
