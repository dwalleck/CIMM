using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIMM.Models;

namespace CIMM.ViewModels
{
    public class AwardAchievementsViewModel
    {

        public ProjectAchievementViewModel [] AchievementStatuses { get; set; }

        public AwardAchievementsViewModel()
        {

        }

        public AwardAchievementsViewModel(ProjectAchievementViewModel [] achievementStatuses)
        {
            AchievementStatuses = achievementStatuses;
        }
    }
}
