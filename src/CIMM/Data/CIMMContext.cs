using CIMM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIMM.Data
{
    public class CIMMContext : DbContext
    {
        public CIMMContext(DbContextOptions<CIMMContext> options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Level> Levels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProjectAchievement>()
                .HasKey(pa => new { pa.ProjectId, pa.AchievementId });

            modelBuilder.Entity<ProjectAchievement>()
                .HasOne(pa => pa.Project)
                .WithMany(p => p.ProjectAchievements)
                .HasForeignKey(pa => pa.ProjectId);

            modelBuilder.Entity<ProjectAchievement>()
                .HasOne(pa => pa.Achievement)
                .WithMany(a => a.ProjectAchievements)
                .HasForeignKey(pa => pa.AchievementId);
        }
    }
}
