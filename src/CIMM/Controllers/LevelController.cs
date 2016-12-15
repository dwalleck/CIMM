using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIMM.Services;
using CIMM.Models;

namespace CIMM.Controllers
{
    public class LevelController : Controller
    {

        private ICIMMDataService _dataService;

        public LevelController(ICIMMDataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            var levels = _dataService.GetLevels();
            return View(levels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Level level)
        {
            if (ModelState.IsValid)
            {
                _dataService.CreateLevel(level);
                return RedirectToAction("Index");
            }

            return View(level);
        }

        public IActionResult Delete(int id)
        {
            _dataService.DeleteLevel(id);
            return RedirectToAction("Index");
        }
    }
}
