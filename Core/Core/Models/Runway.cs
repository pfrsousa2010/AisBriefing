using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Runway: BaseModel
    {
        #region Field
        string rwyIdent;
        string rwySurface;
        string rwyLength;
        string rwyWidth;
        Rotaer rotaer;
        Guid rotaerId;
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
