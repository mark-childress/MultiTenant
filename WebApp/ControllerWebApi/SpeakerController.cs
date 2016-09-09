using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Models;

namespace WebApp.ControllerWebApi
{
    public class SpeakerController : MultiTenantWebApiController
    {
        private readonly MultiTenantContext _context = new MultiTenantContext();

        // GET: api/Session
        public async Task<IEnumerable<Speaker>> Get()
        {
            var speakersAll =
                new TCache<Task<List<Speaker>>>().
                    Get("s-cache", 20,
                        () =>
                        {
                            var speakersAll1 =
                                _context.Speakers.ToListAsync();
                            return speakersAll1;
                        });


            var speakers = new List<Speaker>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var speaker in await speakersAll)
            {
                var speakerInTenant =
                    speaker.Sessions.
                        Any(a => a.Tenant.Name == Tenant.Name);
                if (speakerInTenant)
                {
                    speakers.Add(new Speaker
                    {
                        FirstName = speaker.FirstName,
                        LastName = speaker.LastName,
                        //Id = speaker.Id,
                        Id = speaker.PictureId,
                        PictureId = speaker.PictureId,
                        Bio = speaker.Bio,
                        AllowHtml = speaker.AllowHtml,
                        WebSite = speaker.WebSite,

                        ImageUrl =
                            $"/Content/Images/Speakers/Speaker-{speaker.PictureId}-75.jpg",
                        Sessions =
                            speaker.Sessions.
                                Where(a => a.Tenant.Name == Tenant.Name).
                                OrderBy(a => a.Title).ToList()
                    });
                }
            }

            return speakers.Select(speaker => new Speaker
            {
                Id = speaker.Id,
                FirstName = speaker.FirstName,
                LastName = speaker.LastName,
                Sessions = speaker.Sessions.Select(session => new Session()
                {
                    Id = session.Id,
                    Title = session.Title
                }).ToList()
            });

        }
    }
}
