using MasterDetailUI.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterDetailUI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Master> Masters { get; set; }
        public DbSet<Detail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detail>()
                .HasOne(d => d.Master)
                .WithMany(m => m.Details)
                .HasForeignKey(d => d.MasterId);
        }
    }
}
