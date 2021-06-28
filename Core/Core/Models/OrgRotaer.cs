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
        Rotaer rotaer;
        Guid rotaerId; 
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
        
        public Rotaer Rotaer
        {
            get => rotaer;
            set => SetProperty(ref rotaer, value);
        }
        
        public Guid RotaerId
        {
            get => rotaerId;
            set => SetProperty(ref rotaerId, value);
        }
    }
}
