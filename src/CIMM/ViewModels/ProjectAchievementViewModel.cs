using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.ViewModels
{
    public class ProjectAchievementViewModel
    {
        public int AchievementId { get; set; }
        public string AchievementName { get; set; }
        public bool HasAchievement { get; set; }

        public ProjectAchievementViewModel(int achievementId, string achievementName, bool hasAchievement)
        {
            AchievementId = achievementId;
            AchievementName = achievementName;
            HasAchievement = hasAchievement;
        }
    }
}
