using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Rotaer : BaseModel
    {
        #region Fields
        string latitude;
        string longitude;
        string type; //AD ou HP
        string typeUtil; //PUB, MIL ou PRIV
        string typeOpr; //VFR IFR
        string category; //INTL ou NAC
        string elevationMeters;
        string elevationFeet;
        string fir;
        string utc;

        Location location;
        Guid locationId;
        #endregion

        public string Utc
        {
            get => utc;
            set => SetProperty(ref utc, value);
        }
        public string Fir
        {
            get => fir;
            set => SetProperty(ref fir, value);
        }
        public string ElevationFeet
        {
            get => elevationFeet;
            set => SetProperty(ref elevationFeet, value);
        }
        public string ElevationMeters
        {
            get => elevationMeters;
            set => SetProperty(ref elevationMeters, value);
        }
        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }
        public string TypeOpr
        {
            get => typeOpr;
            set => SetProperty(ref typeOpr, value);
        }
        public string TypeUtil
        {
            get => typeUtil;
            set => SetProperty(ref typeUtil, value);
        }
        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }
        public string Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }
        public string Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
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

        public List<OrgRotaer> Orgs { get; set; }
        public List<Runway> Runways { get; set; }


    }
}
