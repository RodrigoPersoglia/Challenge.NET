using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccesData
{
    public class ChallengeContext : DbContext
    {
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<AvailableResources> AvailableResources { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=RODRIGONOTEBOOK\SQLEXPRESS;Database=Challenge;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }


}
