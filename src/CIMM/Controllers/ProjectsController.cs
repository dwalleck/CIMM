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
            var project = _context.Projects.Where(p => p.Id == id).FirstOrDefault();
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
            var project = _context.Projects.Where(p => p.Id == id).FirstOrDefault();
            if (project == null)
            {
                return NotFound();
            }
            var achievements = _context.Achievements.ToList();
            var achievementsVM = achievements.Select(a => new ProjectAchievementViewModel(a.Id, a.Name, true)).ToArray();

            var vm = new AwardAchievementsViewModel(achievementsVM);
            return View(vm);
        }

        [HttpPost]
        public IActionResult AwardAchievements(int id, AwardAchievementsViewModel vm)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
