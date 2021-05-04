using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Databases
{
    public class LocationsManager : BaseManager<Location>
    {
        public override void Add(Location entity)
        {
            //var aisWebService = new AisWebService();
            //var notams = await aisWebService.GetNotams(entity.IdIcao);

            //foreach (var item in notams)
            //{
            //    foreach(var notam in item.Items)
            //    {
            //        entity.Notams.Add(new Models.Notam 
            //        { 
            //            Message = notam.Text, 
            //        });
            //    }
            //}
            
            base.Add(entity);
        }
    }
}
