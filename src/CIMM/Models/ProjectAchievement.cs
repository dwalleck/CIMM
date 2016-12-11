using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.Models
{
    public class ProjectAchievement
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; }
    }
}
