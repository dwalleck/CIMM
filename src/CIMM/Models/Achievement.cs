using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AchievementType Type { get; set; }
        public int Score { get; set; }

        public List<ProjectAchievement> ProjectAchievements { get; set; }

        public static List<SelectListItem> GetAchievementTypes()
        {
            List<SelectListItem> types = new List<SelectListItem>();
            types.Add(new SelectListItem
            {
                Text = "Select",
                Value = ""
            });

            foreach (AchievementType type in Enum.GetValues(typeof(AchievementType)))
            {
                types.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(AchievementType), type),
                    Value = type.ToString()
                });
            }

            return types;
        }
    }

    public enum AchievementType
    {
        Infrastructure,
        Development,
        Quality,
        DevOps
    }

}
