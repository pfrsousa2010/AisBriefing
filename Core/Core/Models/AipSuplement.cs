using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class AipSuplement : BaseModel
    {
        #region Fields
        string serie;
        string title;
        string text;
        string period;
        Location location;
        Guid locationId;
        #endregion

        public string Serie
        {
            get => serie;
            set => SetProperty(ref serie, value);
        }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string Period
        {
            get => period;
            set => SetProperty(ref period, value);
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
