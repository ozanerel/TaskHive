using Microsoft.EntityFrameworkCore;
using TH.ENTITIES.Models;
using TH.ENTITIES.Enums;

namespace TH.DAL.BogusHandling
{
    public static class TeamMemberSeed
    {
        public static void SeedTeamMembers(ModelBuilder modelBuilder)
        {
            TeamMember adminMember = new()
            {
                Id = 1,
                TeamId = 1,
                UserId = 1,
                TeamRole = TeamRole.Admin
            };

            TeamMember member = new()
            {
                Id = 2,
                TeamId = 1,
                UserId = 2,
                TeamRole = TeamRole.Member
            };

            modelBuilder.Entity<TeamMember>()
                .HasData(adminMember, member);
        }
    }
}