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
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            /*var project = new Project
            {
                Name = "Compute",
                Description = "OpenStack Compute Project",
                CIUrl = "https://jenkins.openstack.org",
                CodeUrl = "https://github.com/openstack/nova",
            };

            context.Projects.Add(project);
            context.SaveChanges();

            var accomplishments = new Accomplishments
            {
                ProjectId = 1,
                HasFunctionalTests = true,
                HasOpsCodeInSourceControl = false,
                HasStaticAnalysis = true,
                HasUnitTestCodeCoverageEnabled = false,
                HasUnitTesting = true
            };

            context.Accomplishments.Add(accomplishments);
            context.SaveChanges();*/
        }
    }
}
