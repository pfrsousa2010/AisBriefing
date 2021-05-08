using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.Business
{
    public class NotamBusiness : BaseBusiness<Notam>
    {
        DateTime? start;
        public DateTime? Start
        {
            get => start;
            set => SetProperty(ref start, value);
        }

        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(sender, e);

            if (e.PropertyName == nameof(Model))
            {
                SetStart();


            }
        }

        private void SetStart()
        {
            try
            {
                if (Model == null)
                {
                    Start = null;
                    return;
                }
                int year = int.Parse("20" + Model.StartDate.Substring(0, 2));
                int mounth = int.Parse(Model.StartDate.Substring(2, 2));
                int day = int.Parse(Model.StartDate.Substring(4, 2));
                int hour = int.Parse(Model.StartDate.Substring(6, 2));
                int minute = int.Parse(Model.StartDate.Substring(8, 2));
                Start = new DateTime(year, mounth, day, hour, minute, 0);
            }
            catch (Exception)
            {
                Start = null;
            }
        }
    }
}
