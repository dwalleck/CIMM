using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CIMM.Data;
using Microsoft.EntityFrameworkCore;
using CIMM.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CIMM.Controllers
{
    public class LeaderboardController : Controller
    {
        private CIMMContext _context;

        public LeaderboardController(CIMMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projects = _context.Projects
                .Include("ProjectAchievements")
                .Include("ProjectAchievements.Achievement")
                .ToList();

            var scoredProjects = projects.Select(p => new ProjectLeaderboardViewModel
                {
                    Name = p.Name,
                    CIUrl = p.CIUrl,
                    TotalScore = p.ProjectAchievements
                        .Where(pa => pa.HasAchievement)
                        .Sum(pa => pa.Achievement.Score)
                })
                .OrderByDescending(p => p.TotalScore)
                .ToList();

            return View(scoredProjects);
        }
    }
}
