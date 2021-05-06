using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Databases
{
    public class LocationsManager : BaseManager<Location>
    {
        public override async Task Add(Location entity)
        {
            var aisWebService = new AisWebService();
            var notams = await aisWebService.GetNotams(entity.IdIcao);

            if (notams == null || notams.Count == 0)
            {
                await base.Add(entity);
                return;
            }

            if (entity.Notams == null)
                entity.Notams = new List<Models.Notam>();

            foreach (var item in notams)
            {
                foreach (var notam in item.Items)
                {
                    entity.Notams.Add(new Models.Notam
                    {
                        Message = notam.Text,
                    });
                }
            }

            await base.Add(entity);
        }
    }
}
