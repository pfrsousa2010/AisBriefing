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

        [JsonIgnore]
        public List<Notam> Notams { get; set; }
        
        [JsonIgnore]
        public List<AipSuplement> AipSuplements { get; set; }        
    }

}
