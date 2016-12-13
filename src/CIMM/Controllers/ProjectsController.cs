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

                // Propigate the achievements for the project
                var achievements = _context.Achievements.ToList();
                var projectAchievements = achievements.Select(a =>
                    new ProjectAchievement
                    {
                        ProjectId = project.ProjectId,
                        HasAchievement = false,
                        AchievementId = a.AchievementId
                    });
                project.ProjectAchievements = new List<ProjectAchievement>();
                project.ProjectAchievements.AddRange(projectAchievements);
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
                _context.Entry(project).Collection(p => p.ProjectAchievements).Load();

                if (project == null)
                {
                    return NotFound();
                }

                foreach (var achievementStatus in vm.AchievementStatuses)
                {
                    var projectAchievement = project.ProjectAchievements.Find(pa => pa.AchievementId == achievementStatus.AchievementId);
                    projectAchievement.HasAchievement = achievementStatus.HasAchievement;
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}
