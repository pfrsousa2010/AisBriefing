using Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core.Models
{
    public class Notam : BaseModel
    {
        #region Fields
        string startDate;
        string endDate;
        string message;
        string notamid;

        Location location;
        Guid locationId;
        #endregion      
       
        public string StartDate
        {
            get => startDate;
            set => SetProperty(ref startDate, value);
        }

        public string EndDate
        {
            get => endDate;
            set => SetProperty(ref endDate, value);
        }

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }
        public string NotamId
        {
            get => notamid;
            set => SetProperty(ref notamid, value);
        }

        [NotMapped] //Não deixa salvar no banco de dados na tabela da Model.
        public string Permanent => GetPermanent();

        [NotMapped]
        public DateTime? Start => GetStart();

        [NotMapped]
        public DateTime? End => GetEnd();

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
        
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(EndDate))
            {
                OnPropertyChanged(Permanent);
                OnPropertyChanged(EndDate);
            }

            if (propertyName == nameof(StartDate))
            {
                OnPropertyChanged(StartDate);
            }
        }

        private string GetPermanent()
        {
            try
            {
                return EndDate == "PERM" ? "permanent".Translate() : null;

            }
            catch (Exception)
            {
                return  null;
            }
        }

        private DateTime? GetEnd()
        {
            try
            {

                int year = int.Parse("20" + EndDate.Substring(0, 2));
                int mounth = int.Parse(EndDate.Substring(2, 2));
                int day = int.Parse(EndDate.Substring(4, 2));
                int hour = int.Parse(EndDate.Substring(6, 2));
                int minute = int.Parse(EndDate.Substring(8, 2));
                return new DateTime(year, mounth, day, hour, minute, 0);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private DateTime? GetStart()
        {
            try
            {
                int year = int.Parse("20" + StartDate.Substring(0, 2));
                int mounth = int.Parse(StartDate.Substring(2, 2));
                int day = int.Parse(StartDate.Substring(4, 2));
                int hour = int.Parse(StartDate.Substring(6, 2));
                int minute = int.Parse(StartDate.Substring(8, 2));
                return new DateTime(year, mounth, day, hour, minute, 0);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }

}
