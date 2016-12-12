using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIMM.Data;
using CIMM.Models;
using CIMM.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CIMM.Controllers
{
    public class ProjectsController : Controller
    {

        private CIMMContext _context;

        public ProjectsController(CIMMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Projects.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public IActionResult Delete(int id)
        {
            var project = _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
            if (project == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult AwardAchievements(int id)
        {
            var project = _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
            if (project == null)
            {
                return NotFound();
            }
            var achievements = _context.Achievements.ToList();
            var achievementsVM = achievements.Select(a => new ProjectAchievementViewModel(a.AchievementId, a.Name, true)).ToArray();

            var vm = new AwardAchievementsViewModel(achievementsVM);
            return View(vm);
        }

        [HttpPost]
        public IActionResult AwardAchievements(int id, AwardAchievementsViewModel vm)
        {

            if (ModelState.IsValid)
            {
                var project = _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
                if (project == null)
                {
                    return NotFound();
                }

                var projectAchievements = vm.AchievementStatuses.Select(
                    a => new ProjectAchievement { ProjectId = project.ProjectId, AchievementId = a.AchievementId, HasAchievement = a.HasAchievement }).ToList();

                if (project.ProjectAchievements == null)
                {
                    project.ProjectAchievements = projectAchievements;
                }
                else
                {
                    //project.ProjectAchievements.ElementAt(0).HasAchievement = false;
                }
                
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}
