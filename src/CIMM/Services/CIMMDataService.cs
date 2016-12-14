using CIMM.Data;
using CIMM.Models;
using CIMM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.Services
{
    public class CIMMDataService : ICIMMDataService
    {
        private CIMMContext _context;

        public CIMMDataService(CIMMContext context)
        {
            _context = context;
        }

        public List<Project> GetProjects() => _context.Projects.ToList();

        public Project GetProjectById(int id) => _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();

        public void CreateProject(Project project)
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
        }
        
        public void DeleteProject(int id)
        {
            var project = _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
            if (project == null)
            {
                return;
            }
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
        
        public void SetProjectAchievements(int id, ProjectAchievementViewModel[] achievementStatuses)
        {
            var project = _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
            _context.Entry(project).Collection(p => p.ProjectAchievements).Load();

            if (project == null)
            {
                return;
            }

            foreach (var achievementStatus in achievementStatuses)
            {
                var projectAchievement = project.ProjectAchievements.Find(pa => pa.AchievementId == achievementStatus.AchievementId);
                projectAchievement.HasAchievement = achievementStatus.HasAchievement;
            }

            _context.SaveChanges();
        }
        
        public List<Achievement> GetAchievements() => _context.Achievements.ToList();

        public Achievement GetAchievementById(int id) => _context.Achievements.Where(a => a.AchievementId == id).FirstOrDefault();

        public void CreateAchievement(Achievement achievement)
        {
            _context.Achievements.Add(achievement);
            _context.SaveChanges();

            // Add the achievement to all projects
            var projects = _context.Projects.ToList();
            foreach (var project in projects)
            {
                if (project.ProjectAchievements == null)
                {
                    project.ProjectAchievements = new List<ProjectAchievement>();
                }
                project.ProjectAchievements.Add(new ProjectAchievement
                {
                    ProjectId = project.ProjectId,
                    HasAchievement = false,
                    AchievementId = achievement.AchievementId
                });
            }
            _context.SaveChanges();
        }
        
        public void DeleteAchievement(int id)
        {
            var achievement = _context.Achievements.Where(a => a.AchievementId == id).FirstOrDefault();
            if (achievement == null)
            {
                return;
            }
            _context.Achievements.Remove(achievement);
            _context.SaveChanges();
        }
        
        public void SetProjectAchievements(int id, List<ProjectAchievementViewModel> projectAchievementStatuses)
        {
            var project = _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
            _context.Entry(project).Collection(p => p.ProjectAchievements).Load();

            if (project == null)
            {
                return;
            }

            foreach (var achievementStatus in projectAchievementStatuses)
            {
                var projectAchievement = project.ProjectAchievements.Find(pa => pa.AchievementId == achievementStatus.AchievementId);
                projectAchievement.HasAchievement = achievementStatus.HasAchievement;
            }

            _context.SaveChanges();
        }    
    }
}
