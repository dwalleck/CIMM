using CIMM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.ViewModels
{
    public class CreateAchievementViewModel
    {
        public Achievement Achievement { get; set; }
        public List<SelectListItem> AchievementTypes { get; set; }

        public CreateAchievementViewModel()
        {
            var types = new List<SelectListItem>();
            
            foreach (AchievementType type in Enum.GetValues(typeof(AchievementType)))
            {
                types.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(AchievementType), type),
                    Value = type.ToString()
                });
            }

            AchievementTypes = types;
        }
    }
}
