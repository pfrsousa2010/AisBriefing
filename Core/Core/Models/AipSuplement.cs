using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class AipSuplement : BaseModel
    {
        #region Fields
        string supId;
        string title;
        string text;
        string period;
        Location location;
        #endregion

        public string SupId
        {
            get => supId;
            set => SetProperty(ref supId, value);
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

    }
}
