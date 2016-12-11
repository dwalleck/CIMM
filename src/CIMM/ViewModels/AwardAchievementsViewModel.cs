using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIMM.Models;

namespace CIMM.ViewModels
{
    public class AwardAchievementsViewModel
    {

        public string ProjectName { get; set; }
        public List<ProjectAchievementViewModel> AchievementStatuses { get; set; }

        public AwardAchievementsViewModel()
        {

        }

        public AwardAchievementsViewModel(string name, List<ProjectAchievementViewModel> achievementStatuses)
        {
            ProjectName = name;
            AchievementStatuses = achievementStatuses;
        }
    }
}
