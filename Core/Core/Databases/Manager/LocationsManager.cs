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
            return entities
                .Include(Location => Location.Notams)
                .Include(Location => Location.AipSuplements)
                .Include(Location => Location.Metars)
                .Include(Location => Location.Tafs)
                .Include(Location => Location.Runways)
                .Include(Location => Location.OrgRotaers);
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
            var sunTimeWeb = await aisWebService.GetSunSetSunRise(entity.IdIcao);
            var metarAisWeb = await aisWebService.GetMetar(entity.IdIcao);
            var tafAisWeb = await aisWebService.GetTaf(entity.IdIcao);

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
                entity.Utc = rotaerAisWeb.UtcRotaer;
                entity.Category = rotaerAisWeb.CategoryRotaer;
                entity.ElevationFeet = rotaerAisWeb.altFeetRotaer;
                entity.ElevationMeters = rotaerAisWeb.altMetersRotaer;
                entity.Fir = rotaerAisWeb.FirRotaer;
                entity.Latitude = rotaerAisWeb.LatRotaer;
                entity.Longitude = rotaerAisWeb.LngRotaer;
                entity.Type = rotaerAisWeb.TypeRotaer;
                entity.TypeOpr = rotaerAisWeb.TypeOprRotaer;
                entity.TypeUtil = rotaerAisWeb.TypeUtilRotaer;

                if (rotaerAisWeb.Orgs?.Count > 0)
                {
                    if (entity.OrgRotaers == null)
                    {
                        entity.OrgRotaers = new List<Models.OrgRotaer>();
                    }

                    foreach (var org in rotaerAisWeb.Orgs)
                    {
                        entity.OrgRotaers.Add(new Models.OrgRotaer
                        {
                            Name = org.Name,
                            Type = org.Type
                        });
                    }
                }

                if (rotaerAisWeb.Runways?.Count > 0)
                {
                    if (entity.Runways == null)
                    {
                        entity.Runways = new List<Models.Runway>();
                    }

                    foreach (var runway in rotaerAisWeb.Runways)
                    {
                        foreach (var item in runway.Items)
                        {
                            entity.Runways.Add(new Models.Runway
                            {
                                RwyIdent = item.IdentRwy,
                                RwySurface = item.SurfaceRwy,
                                RwyLength = item.LengthRwy,
                                RwyWidth = item.WidthRwy
                            });
                        }
                    }
                }
            }

            //Add SunSetSunRise Informations
            if (sunTimeWeb != null)
            {
                entity.SunRise = sunTimeWeb.SunRiseWeb;
                entity.SunSet = sunTimeWeb.SunSetWeb;
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
                        entity.FlightOperation = metar.FlightCat;
                        break;
                    }

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

            //Add Taf Informations
            if (tafAisWeb?.Count > 0)
            {
                if (entity.Tafs == null)
                {
                    entity.Tafs = new List<Models.Taf>();
                }

                foreach (var item in tafAisWeb)
                {
                    foreach (var taf in item.Items)
                    {
                        entity.Tafs.Add(new Models.Taf
                        {
                            MessageTaf = taf.MsgTaf                            
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
                await RefreshMetars(entities);
                await RefreshTafs(entities);

                foreach (var item in entities)
                {
                    await RefreshAipSuplements(item);
                    await RefreshSunTime(item);
                    await RefreshRotaer(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task RefreshSunTime(Location location)
        
        {
            var aisWebService = new AisWebService();
            var sunTimeWeb = await aisWebService.GetSunSetSunRise(location.IdIcao);

            if (sunTimeWeb != null)
            {
                location.SunRise = sunTimeWeb.SunRiseWeb;
                location.SunSet = sunTimeWeb.SunSetWeb;

                Database.Update(location);
            }

            Database.SaveChanges();
        }

        public async Task RefreshRotaer(Location location)
        {
            var aisWebService = new AisWebService();
            var rotaerAisWeb = await aisWebService.GetRotaer(location.IdIcao);

            if (rotaerAisWeb != null)
            {
                location.Utc = rotaerAisWeb.UtcRotaer;
                location.Category = rotaerAisWeb.CategoryRotaer;
                location.ElevationFeet = rotaerAisWeb.altFeetRotaer;
                location.ElevationMeters = rotaerAisWeb.altMetersRotaer;
                location.Fir = rotaerAisWeb.FirRotaer;
                location.Latitude = rotaerAisWeb.LatRotaer;
                location.Longitude = rotaerAisWeb.LngRotaer;
                location.Type = rotaerAisWeb.TypeRotaer;
                location.TypeOpr = rotaerAisWeb.TypeOprRotaer;
                location.TypeUtil = rotaerAisWeb.TypeUtilRotaer;

                var oldOrgRotaer = Database.OrgRotaers.Where(s => s.LocationId == location.Id);
                Database.RemoveRange(oldOrgRotaer);

                if (rotaerAisWeb.Orgs?.Count > 0)
                {
                    foreach (var org in rotaerAisWeb.Orgs)
                    {
                        var newOrgRotaer = new OrgRotaer
                        {
                            Name = org.Name,
                            Type = org.Type,
                            Location = location
                        };

                        Database.Add(newOrgRotaer);
                    }
                }

                var oldRunways = Database.Runways.Where(s => s.LocationId == location.Id);
                Database.RemoveRange(oldRunways);

                if (rotaerAisWeb.Runways?.Count > 0)
                {
                    foreach (var runway in rotaerAisWeb.Runways)
                    {
                        foreach (var item in runway.Items)
                        {

                            var newRunway = new Runway
                            {
                                RwyIdent = item.IdentRwy,
                                RwySurface = item.SurfaceRwy,
                                RwyLength = item.LengthRwy,
                                RwyWidth = item.WidthRwy,
                                Location = location
                            };

                            Database.Add(newRunway);
                        }
                    }
                }

                Database.Update(location);
            }

            Database.SaveChanges();
        }

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

        public async Task RefreshMetars(List<Location> entities)
        {

            var icaoIds = string.Join(",", entities.Select(s => s.IdIcao));
            var locationIds = entities.Select(s => s.Id);

            var oldMetars = Database.Metars.Where(s => locationIds.Contains(s.LocationId));
            Database.RemoveRange(oldMetars);

            var aisWebService = new AisWebService();

            var metarsAisWeb = await aisWebService.GetMetar(icaoIds);

            // add metars
            if (metarsAisWeb != null || metarsAisWeb.Count > 0)
            {

                foreach (var item in metarsAisWeb)
                {
                    foreach (var metar in item.Items)
                    {
                        var location = entities.Where(l => l.IdIcao == metar.StationId).FirstOrDefault();

                        location.FlightOperation = metar.FlightCat;
                        break;
                    }

                }

                foreach (var item in metarsAisWeb)
                {
                    foreach (var metar in item.Items)
                    {
                        var location = entities.Where(l => l.IdIcao == metar.StationId).FirstOrDefault();
                        
                        var newMetar = new Models.Metar
                        {
                            MessageMetar = metar.MsgMetar,
                            FlightCategory = metar.FlightCat,
                            Location = location
                        };

                        Database.Add(newMetar);
                    }
                }

            }

            Database.SaveChanges();

        }

        public async Task RefreshTafs(List<Location> entities)
        {

            var icaoIds = string.Join(",", entities.Select(s => s.IdIcao));
            var locationIds = entities.Select(s => s.Id);

            var oldTafs = Database.Tafs.Where(s => locationIds.Contains(s.LocationId));
            Database.RemoveRange(oldTafs);

            var aisWebService = new AisWebService();

            var tafsAisWeb = await aisWebService.GetTaf(icaoIds);

            // add metars
            if (tafsAisWeb != null || tafsAisWeb.Count > 0)
            {
                foreach (var item in tafsAisWeb)
                {
                    foreach (var taf in item.Items)
                    {
                        var location = entities.Where(l => l.IdIcao == taf.StationId).FirstOrDefault();

                        var newTaf = new Models.Taf
                        {
                            MessageTaf = taf.MsgTaf,
                            Location = location
                        };

                        Database.Add(newTaf);
                    }
                }

            }

            Database.SaveChanges();

        }


    }
}
