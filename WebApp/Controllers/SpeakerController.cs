﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SpeakerController : MultiTenantMvcController
    {


        private MultiTenantContext context = new MultiTenantContext();

        [MultiTenantControllerAllow("svcc,angu,cscc")]

        public async Task<ActionResult> Index()
        {
            var speakers = new List<Speaker>();


            Task<List<Speaker>> speakersAll =
                new TCache<Task<List<Speaker>>>().
                Get("s-cache", 20,
                    () =>
                    {
                        var speakersAll1 =
                            context.Speakers.ToListAsync();
                        return speakersAll1;
                    });


            foreach (var speaker in await speakersAll)
            {
                bool speakerInTenant =
                    speaker.Sessions.
                    Any(a => a.Tenant.Name == Tenant.Name);
                if (speakerInTenant)
                {
                    speakers.Add(new Speaker
                    {
                        FirstName = speaker.FirstName,
                        LastName = speaker.LastName,
                        Id = speaker.Id,
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

            return View("Index","_Layout", speakers);
        }

    }
}
