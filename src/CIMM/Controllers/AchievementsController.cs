using Microsoft.AspNetCore.Mvc;
using CIMM.Data;
using System.Linq;
using CIMM.Models;
using CIMM.ViewModels;
using System.Collections.Generic;
using CIMM.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CIMM.Controllers
{
    public class AchievementsController : Controller
    {

        private ICIMMDataService _dataService;

        public AchievementsController(ICIMMDataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            return View(_dataService.GetAchievements());
        }

        public IActionResult Create()
        {
            var vm = new CreateAchievementViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateAchievementViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _dataService.CreateAchievement(vm.Achievement);
                return RedirectToAction("Index");
            }
            return View(vm.Achievement);
        }

        public IActionResult Delete(int id)
        {
            _dataService.DeleteAchievement(id);
            return RedirectToAction("Index");
        }
    }
}
