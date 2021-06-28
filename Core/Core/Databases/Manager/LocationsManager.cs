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
            return entities.Include(Location => Location.Notams)
                .Include(Location => Location.AipSuplements)
                .Include(Location => Location.Rotaer)
                .Include(Location => Location.Rotaer.Orgs)
                .Include(Location => Location.Rotaer.Runways);
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
            var rotaerAisWeb = await aisWebService.GetRotaer(entity.IdIcao);
            var metarAisWeb = await aisWebService.GetMetar(entity.IdIcao);

            //Add NOTAMS
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
            //Add AipSuplements
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
            //Add Rotaer Informations
            if (rotaerAisWeb != null)
            {
                var newRotaer = new Rotaer
                {
                    Utc = rotaerAisWeb.UtcRotaer,
                    Category = rotaerAisWeb.CategoryRotaer,
                    ElevationFeet = rotaerAisWeb.altFeetRotaer,
                    ElevationMeters = rotaerAisWeb.altMetersRotaer,
                    Fir = rotaerAisWeb.FirRotaer,
                    Latitude = rotaerAisWeb.LatRotaer,
                    Longitude = rotaerAisWeb.LngRotaer,
                    Type = rotaerAisWeb.TypeRotaer,
                    TypeOpr = rotaerAisWeb.TypeOprRotaer,
                    TypeUtil = rotaerAisWeb.TypeUtilRotaer
                };

                if (rotaerAisWeb.Orgs?.Count > 0)
                {
                    newRotaer.Orgs = new List<OrgRotaer>();

                    foreach(var item in rotaerAisWeb.Orgs)
                    {
                        newRotaer.Orgs.Add(new OrgRotaer 
                        {
                            Name = item.Name,
                            Type = item.Type
                        });
                    }
                }

                if (rotaerAisWeb.Runways?.Count > 0)
                {
                    newRotaer.Runways = new List<Runway>();

                    foreach (var runway in rotaerAisWeb.Runways)
                    {
                        foreach(var item in runway.Items)
                        {
                            newRotaer.Runways.Add(new Runway
                            {
                                RwyWidth = item.WidthRwy,
                                RwyLength = item.LengthRwy,
                                RwySurface = item.SurfaceRwy,
                                RwyIdent = item.IdentRwy
                            });
                        }
                    }
                }

                entity.Rotaer = newRotaer;
            }

            //Add Metar Informations
            if (metarAisWeb?.Count > 0)
            {
                if (entity.Metars == null)
                {
                    entity.Metars = new List<Models.Metar>();
                }

                foreach (var item in metarAisWeb)
                {
                    foreach (var metar in item.Items)
                    {
                        entity.Metars.Add(new Models.Metar
                        {
                            MessageMetar = metar.MsgMetar,
                            FlightCategory = metar.FlightCat
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
                var conectivity = Xamarin.Essentials.Connectivity.NetworkAccess;

                if (conectivity != Xamarin.Essentials.NetworkAccess.Internet ||
                    entities.Count == 0)
                {
                    return;
                }

                await RefreshNotams(entities);

                foreach (var item in entities)
                {
                    await RefreshAipSuplements(item);
                    //await RefreshRotaer(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        //public async Task RefreshRotaer(Location location)
        //{
        //    //var oldrotaers = Database.Rotaers.Where(s => s.LocationId == location.Id);
        //    //Database.Remove(oldrotaers);
        //    //Database.SaveChanges();

        //    var aisWebService = new AisWebService();
        //    var rotaerAisWeb = await aisWebService.GetRotaer(location.IdIcao);

        //    if (rotaerAisWeb != null)
        //    {
        //        var newRotaer = new Rotaer
        //        {
        //            Utc = rotaerAisWeb.UtcRotaer,
        //            Category = rotaerAisWeb.CategoryRotaer,
        //            ElevationFeet = rotaerAisWeb.altFeetRotaer,
        //            ElevationMeters = rotaerAisWeb.altMetersRotaer,
        //            Fir = rotaerAisWeb.FirRotaer,
        //            Latitude = rotaerAisWeb.LatRotaer,
        //            Longitude = rotaerAisWeb.LngRotaer,
        //            Type = rotaerAisWeb.TypeRotaer,
        //            TypeOpr = rotaerAisWeb.TypeOprRotaer,
        //            TypeUtil = rotaerAisWeb.TypeUtilRotaer                    
        //        };

        //        if (rotaerAisWeb.Orgs?.Count > 0)
        //        {
        //            newRotaer.Orgs = new List<OrgRotaer>();

        //            foreach (var item in rotaerAisWeb.Orgs)
        //            {
        //                newRotaer.Orgs.Add(new OrgRotaer
        //                {
        //                    Name = item.Name,
        //                    Type = item.Type
        //                });
        //            }
        //        }

        //        if (rotaerAisWeb.Runways?.Count > 0)
        //        {
        //            newRotaer.Runways = new List<Runway>();

        //            foreach (var runway in rotaerAisWeb.Runways)
        //            {
        //                foreach (var item in runway.Items)
        //                {
        //                    newRotaer.Runways.Add(new Runway
        //                    {
        //                        RwyWidth = item.WidthRwy,
        //                        RwyLength = item.LengthRwy,
        //                        RwySurface = item.SurfaceRwy,
        //                        RwyIdent = item.IdentRwy
        //                    });
        //                }
        //            }
        //        }

        //        Database.Add(newRotaer);

        //    }

        //    Database.SaveChanges();
        //}

        public async Task RefreshAipSuplements(Location location)
        {
            var oldAipSuplements = Database.AipSuplements.Where(s => s.LocationId == location.Id);
            Database.RemoveRange(oldAipSuplements);
            Database.SaveChanges();

            var aisWebService = new AisWebService();
            var aipSuplementWeb = await aisWebService.GetAipSuplements(location.IdIcao);

            if (aipSuplementWeb == null || aipSuplementWeb.Count == 0)
            {
                return;
            }

            foreach (var item in aipSuplementWeb)
            {
                foreach (var aipSuplement in item.Items)
                {
                    var newAipSuplement = new Models.AipSuplement
                    {
                        Serie = aipSuplement.SerieSup,
                        Title = aipSuplement.TitleSup,
                        Text = aipSuplement.TextSup,
                        Period = aipSuplement.PeriodSup,
                        Location = location
                    };

                    Database.Add(newAipSuplement);
                }
            }

            Database.SaveChanges();
        }

        public async Task RefreshNotams(List<Location> entities)
        {

            var icaoIds = string.Join(",", entities.Select(s => s.IdIcao));
            var locationIds = entities.Select(s => s.Id);

            var oldNotams = Database.Notams.Where(s => locationIds.Contains(s.LocationId));
            Database.RemoveRange(oldNotams);            

            var aisWebService = new AisWebService();

            var notamsAisWeb = await aisWebService.GetNotams(icaoIds);

            // add notams
            if (notamsAisWeb != null || notamsAisWeb.Count > 0)
            {
                foreach (var item in notamsAisWeb)
                {
                    foreach (var notam in item.Items)
                    {
                        var location = entities.Where(l => l.IdIcao == notam.Icao).FirstOrDefault();

                        var newNotam = new Models.Notam
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

            }

            Database.SaveChanges();        

        }
    }
}
