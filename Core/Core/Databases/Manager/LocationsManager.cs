using Core.Models;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Databases
{
    public class LocationsManager : BaseManager<Location>
    {
        //Load the Notams added by location on starting
        public override IQueryable<Location> GetIncludes(IQueryable<Location> entities)
        {
            return entities.Include(Location => Location.Notams);
        }

        public override async Task<IQueryable<Location>> GetAll()
        {
            var locations = await base.GetAll();
            await RefreshRange(locations.ToList());
            return locations;
        }

        public override async Task Add(Location entity)
        {
            #region Conectivity Test
            var conectivity = Xamarin.Essentials.Connectivity.NetworkAccess;

            if (conectivity != Xamarin.Essentials.NetworkAccess.Internet)
            {
                await base.Add(entity);
                return;
            } 
            #endregion

            var aisWebService = new AisWebService();
            var notamsAisWeb = await aisWebService.GetNotams(entity.IdIcao);
            var aipSuplementsAisWeb = await aisWebService.GetAipSuplements(entity.IdIcao);

            if (notamsAisWeb?.Count > 0)
            {
                if (entity.Notams == null)
                {
                    entity.Notams = new List<Models.Notam>();
                }

                foreach (var item in notamsAisWeb)
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
            }

            if (aipSuplementsAisWeb?.Count > 0)
            {
                if (entity.AipSuplements == null)
                {
                    entity.AipSuplements = new List<Models.AipSuplement>();
                }

                foreach (var item in aipSuplementsAisWeb)
                {
                    foreach (var aipSuplement in item.Items)
                    {
                        entity.AipSuplements.Add(new Models.AipSuplement
                        {
                            Serie = aipSuplement.SerieSup,
                            Title = aipSuplement.TitleSup,
                            Text = aipSuplement.TextSup,
                            Period = aipSuplement.PeriodSup
                        });
                    }
                }

            }

            await base.Add(entity);
        }

        public override async Task RefreshRange(List<Location> entities)
        {
            try
            {
                #region Conectivity Test
                var conectivity = Xamarin.Essentials.Connectivity.NetworkAccess;

                if (conectivity != Xamarin.Essentials.NetworkAccess.Internet ||
                    entities.Count == 0)
                {
                    return;
                } 
                #endregion

                var icaoIds = string.Join(",", entities.Select(s => s.IdIcao));
                var locationIds = entities.Select(s => s.Id);

                var oldNotams = Database.Notams.Where(s => locationIds.Contains(s.LocationId));
                Database.RemoveRange(oldNotams);
                Database.SaveChanges();

                var aisWebService = new AisWebService();
                var notams = await aisWebService.GetNotams(icaoIds);
                //var aipSuplement = await aisWebService.GetAipSuplements(icaoIds);

                if (notams == null || notams.Count == 0)
                {
                    return;
                }

                foreach (var item in notams)
                {
                    foreach (var notam in item.Items)
                    {
                        var location = entities.Where(l => l.IdIcao == notam.Icao).FirstOrDefault();

                        var newNotam =new Models.Notam
                        {
                            NotamId = notam.IdNotam,
                            Message = notam.Text,
                            StartDate = notam.StDate,
                            EndDate = notam.EdDate,
                            Location = location
                        };

                        Database.Add(newNotam);
                    }
                }

                Database.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

                   
        }
    }
}
