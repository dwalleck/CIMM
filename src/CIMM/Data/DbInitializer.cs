using CIMM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CIMMContext context)
        {
            // For now, start clean
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            /*var nova = new Project
            {
                Name = "Compute",
                Description = "OpenStack Compute Project",
                CIUrl = "https://jenkins.openstack.org",
                CodeUrl = "https://github.com/openstack/nova",
            };
            context.Projects.Add(nova);

            var cinder = new Project
            {
                Name = "Cinder",
                Description = "OpenStack Block Storage Project",
                CIUrl = "https://jenkins.openstack.org",
                CodeUrl = "https://github.com/openstack/cinder",
            };
            context.Projects.Add(cinder);

            var ciServer = new Achievement
            {
                Name = "CI Server Setup",
                Description = "You have a CI server.",
                Type = AchievementType.Quality,
                Score = 10
            };


            context.SaveChanges();*/

        }
    }
}
