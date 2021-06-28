using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Metar : BaseModel
    {
        #region Fields
        string messageMetar;
        string flightCategory;

        Location location;
        Guid locationId;
        #endregion

        public string MessageMetar
        {
            get => messageMetar;
            set => SetProperty(ref messageMetar, value);
        }

        public string FlightCategory
        {
            get => flightCategory;
            set => SetProperty(ref flightCategory, value);
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
