using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Core.Extensions;

namespace Core.Business
{
    public class NotamBusiness : BaseBusiness<Notam>
    {
        #region Fields
        DateTime? start;
        DateTime? end;
        string permanent;
        #endregion
        public DateTime? Start
        {
            get => start;
            set => SetProperty(ref start, value);
        }
        public DateTime? End
        {
            get => end;
            set => SetProperty(ref end, value);
        }
        public string Permanent
        {
            get => permanent;
            set => SetProperty(ref permanent, value);
        }

        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(sender, e);

            if (e.PropertyName == nameof(Model))
            {
                SetStart();
                SetEnd();
                SetPerm();
            }
        }

        private void SetPerm()
        {
            try
            {
                if (Model == null)
                {
                    Permanent = null;
                    return;
                }
                                
                Permanent = Model.EndDate == "PERM" ? "permanent".Translate() : null;

            }
            catch (Exception)
            {
                Permanent = null;
            }
        }

        private void SetEnd()
        {
            try
            {   
                if (Model == null || Model.EndDate == "PERM")
                {
                    End = null;
                    return;
                }

                int year = int.Parse("20" + Model.EndDate.Substring(0, 2));
                int mounth = int.Parse(Model.EndDate.Substring(2, 2));
                int day = int.Parse(Model.EndDate.Substring(4, 2));
                int hour = int.Parse(Model.EndDate.Substring(6, 2));
                int minute = int.Parse(Model.EndDate.Substring(8, 2));
                End = new DateTime(year, mounth, day, hour, minute, 0); 
            }
            catch (Exception)
            {
                End = null;
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