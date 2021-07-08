using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Location : BaseModel
    {
        #region Fields
        string idIcao; 
        string name;
        string city;
        string country;
        string sunRise;
        string sunSet;
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

        List<Metar> metars;
        List<Taf> tafs;
        #endregion


        [JsonProperty(PropertyName = "icao")]
        public string IdIcao
        {
            get => idIcao;
            set => SetProperty(ref idIcao, value);
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        [JsonProperty(PropertyName = "city")]
        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }
        [JsonProperty(PropertyName = "country")]
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }

        #region SunTimes
        [JsonIgnore]
        public string SunRise
        {
            get => sunRise;
            set => SetProperty(ref sunRise, value);
        }

        [JsonIgnore]
        public string SunSet
        {
            get => sunSet;
            set => SetProperty(ref sunSet, value);
        }
        #endregion

        #region Rotaer
        [JsonIgnore]
        public string Utc
        {
            get => utc;
            set => SetProperty(ref utc, value);
        }
        [JsonIgnore]
        public string Fir
        {
            get => fir;
            set => SetProperty(ref fir, value);
        }
        [JsonIgnore]
        public string ElevationFeet
        {
            get => elevationFeet;
            set => SetProperty(ref elevationFeet, value);
        }
        [JsonIgnore]
        public string ElevationMeters
        {
            get => elevationMeters;
            set => SetProperty(ref elevationMeters, value);
        }
        [JsonIgnore]
        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }
        [JsonIgnore]
        public string TypeOpr
        {
            get => typeOpr;
            set => SetProperty(ref typeOpr, value);
        }
        [JsonIgnore]
        public string TypeUtil
        {
            get => typeUtil;
            set => SetProperty(ref typeUtil, value);
        }
        [JsonIgnore]
        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }
        [JsonIgnore]
        public string Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }
        [JsonIgnore]
        public string Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
        }
        #endregion    

        [JsonIgnore]
        public List<Notam> Notams { get; set; }
        
        [JsonIgnore]
        public List<AipSuplement> AipSuplements { get; set; }

        [JsonIgnore]
        public List<Runway> Runways { get; set; }
        public List<OrgRotaer> OrgRotaers { get; set; }

        [JsonIgnore]
        public List<Metar> Metars
        {
            get => metars;
            set
            {
                SetProperty(ref metars, value);
                OnPropertyChanged(nameof(HasMetar));
            }
        }

        [JsonIgnore]
        public List<Taf> Tafs
        {
            get => tafs;
            set
            {
                SetProperty(ref tafs, value);
                OnPropertyChanged(nameof(HasTaf));
            }
        }

        public bool HasMetar => Metars?.Count > 0;
        public bool HasTaf => Tafs?.Count > 0;
    }

}
