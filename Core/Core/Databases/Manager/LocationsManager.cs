using Core.Models;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Databases
{
    public class LocationsManager : BaseManager<Location>
    {
        //Load the Notams added by location
        public override IQueryable<Location> GetIncludes(IQueryable<Location> entities)
        {
            return entities.Include(Location => Location.Notams);
        }
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
                        NotamId = notam.IdNotam,
                        Message = notam.Text,
                        StartDate = notam.StDate,
                        EndDate = notam.EdDate
                    });
                }
                
            }
            await base.Add(entity);
        }

        public override async Task RefreshRange(List<Location> entities)
        {

            foreach (var location in entities)
            {
                Database.RemoveRange(location.Notams);
            }

            Database.SaveChanges();


            var icaoIds = string.Join(",", entities.Select(s => s.IdIcao));

            var aisWebService = new AisWebService();
            var notams = await aisWebService.GetNotams(icaoIds);

            if (notams == null || notams.Count == 0)
            {
                return;
            }

            foreach (var item in notams)
            {

                foreach (var notam in item.Items)
                {
                    var location = entities.Where(l => l.IdIcao == notam.Icao).FirstOrDefault();

                    location.Notams.Add(new Models.Notam
                    {
                        NotamId = notam.IdNotam,
                        Message = notam.Text,
                        StartDate = notam.StDate,
                        EndDate = notam.EdDate
                    });

                    Database.Update(location);
                }
            }
            
            Database.SaveChanges();
        }
    }
}
