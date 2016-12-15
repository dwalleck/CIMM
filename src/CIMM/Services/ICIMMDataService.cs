using CIMM.Models;
using CIMM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.Services
{
    public interface ICIMMDataService
    {
        List<Project> GetProjects();
        Project GetProjectById(int id);
        void CreateProject(Project project);
        void DeleteProject(int id);
        void SetProjectAchievements(int id, ProjectAchievementViewModel[] achievementStatuses);
        List<Achievement> GetAchievements();
        Achievement GetAchievementById(int id);
        void CreateAchievement(Achievement achievement);
        void DeleteAchievement(int id);
        void SetProjectAchievements(int id, List<ProjectAchievementViewModel> projectAchievementStatuses);
        List<Level> GetLevels();
        Level GetLevelById(int id);
        void CreateLevel(Level level);
        void DeleteLevel(int id);
    }
}
