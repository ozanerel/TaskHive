using Microsoft.EntityFrameworkCore;
using TH.ENTITIES.Models;

namespace TH.DAL.BogusHandling
{
    public static class TeamSeed
    {
        public static void SeedTeams(ModelBuilder modelBuilder)
        {
            Team team = new()
            {
                Id = 1,
                Name = "TaskHive Development Team",
                Description = "TaskHive projesini geliştiren ekip."
            };

            modelBuilder.Entity<Team>().HasData(team);
        }
    }
}