using Microsoft.EntityFrameworkCore;
using NewSystem.Domain.Product;
using NewSystem.Domain.Player;
using NewSystem.Domain.Score;

namespace NewSystem.Data
{
    public class NewSystemContext : DbContext
    {
        public NewSystemContext(DbContextOptions<NewSystemContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<Score> Scores { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NewSystemContext).Assembly);
        }
    }
}
