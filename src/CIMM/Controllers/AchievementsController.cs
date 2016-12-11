using Microsoft.AspNetCore.Mvc;
using CIMM.Data;
using System.Linq;
using CIMM.Models;
using CIMM.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CIMM.Controllers
{
    public class AchievementsController : Controller
    {

        private CIMMContext _context;

        public AchievementsController(CIMMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Achievements.ToList());
        }

        public IActionResult Create()
        {
            var vm = new CreateAchievementViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CreateAchievementViewModel vm)
        {
            var achievement = vm.Achievement;
            if (ModelState.IsValid)
            {
                _context.Achievements.Add(achievement);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(achievement);
        }

        public IActionResult Delete(int id)
        {
            var achievement = _context.Achievements.Where(a => a.Id == id).FirstOrDefault();
            if (achievement == null)
            {
                return NotFound();
            }
            _context.Achievements.Remove(achievement);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
