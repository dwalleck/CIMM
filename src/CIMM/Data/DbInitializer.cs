using CIMM.Models;
using CIMM.Services;
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
            context.SaveChanges();

            var dataService = new CIMMDataService(context);
            var nova = new Project
            {
                Name = "Compute",
                Description = "OpenStack Compute Project",
                CIUrl = "https://jenkins.openstack.org",
                CodeUrl = "https://github.com/openstack/nova",
            };
            dataService.CreateProject(nova);

            var cinder = new Project
            {
                Name = "Cinder",
                Description = "OpenStack Block Storage Project",
                CIUrl = "https://jenkins.openstack.org",
                CodeUrl = "https://github.com/openstack/cinder",
            };
            dataService.CreateProject(cinder);

            var ciServer = new Achievement
            {
                Name = "CI Server Setup",
                Description = "You have a CI server.",
                Type = AchievementType.Quality,
                Score = 10
            };
            dataService.CreateAchievement(ciServer);

            var unitTests = new Achievement
            {
                Name = "Basic Unit Tests",
                Description = "You have basic unit tests.",
                Type = AchievementType.Development,
                Score = 5
            };
            dataService.CreateAchievement(unitTests);

        }
    }
}
