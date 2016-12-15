using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIMM.Data;
using CIMM.Models;
using CIMM.ViewModels;
using CIMM.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CIMM.Controllers
{
    public class ProjectsController : Controller
    {

        private ICIMMDataService _dataService;

        public ProjectsController(ICIMMDataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            return View(_dataService.GetProjects());
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
                _dataService.CreateProject(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public IActionResult Delete(int id)
        {
            _dataService.DeleteProject(id);
            return RedirectToAction("Index");
        }

        public IActionResult AwardAchievements(int id)
        {
            var project = _dataService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }

            var achievementsVM = project.ProjectAchievements.Select(pa => 
                new ProjectAchievementViewModel(pa.AchievementId, pa.Achievement.Name, pa.HasAchievement)).ToArray();
            var vm = new AwardAchievementsViewModel(achievementsVM);
            return View(vm);
        }

        [HttpPost]
        public IActionResult AwardAchievements(int id, AwardAchievementsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _dataService.SetProjectAchievements(id, vm.AchievementStatuses);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}
