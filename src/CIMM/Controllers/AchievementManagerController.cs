using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIMM.Data;
using CIMM.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CIMM.Controllers
{
    public class AchievementManagerController : Controller
    {
        private CIMMContext _context;

        public AchievementManagerController(CIMMContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            var achievements = _context.Achievements.ToList();
            var achievementsVM = achievements.Select(a => new ProjectAchievementViewModel(a.AchievementId, a.Name, false)).ToArray();

            return View(achievementsVM);
        }

        [HttpPost]
        public IActionResult Create(ProjectAchievementViewModel[] vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
