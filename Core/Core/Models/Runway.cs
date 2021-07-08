using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Runway : BaseModel
    {
        #region Fields
        string rwyIdent;
        string rwySurface;
        string rwyLength;
        string rwyWidth;

        Location location;
        Guid locationId; 
        #endregion

        public string RwyWidth
        {
            get => rwyWidth;
            set => SetProperty(ref rwyWidth, value);
        }
        public string RwyLength
        {
            get => rwyLength;
            set => SetProperty(ref rwyLength, value);
        }
        public string RwySurface
        {
            get => rwySurface;
            set => SetProperty(ref rwySurface, value);
        }
        public string RwyIdent
        {
            get => rwyIdent;
            set => SetProperty(ref rwyIdent, value);
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
