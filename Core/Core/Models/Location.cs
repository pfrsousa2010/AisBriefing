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
        #endregion

        public string IdIcao
        {
            get => idIcao;
            set => SetProperty(ref idIcao, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public List<Notam> Notams { get; set; }
        public List<AipSuplement> AipSuplements { get; set; }        
    }



}
