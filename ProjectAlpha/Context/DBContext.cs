using Microsoft.EntityFrameworkCore;
using ProjectAlpha.Entities;

namespace ProjectAlpha.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Message> Staffs { get; set; }
        public DbSet<Message> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>().Property(x => x.Id);
            modelBuilder.Entity<Project>().Property(x => x.Id);
            modelBuilder.Entity<Project>().HasMany(x => x.Activities);
            modelBuilder.Entity<Message>().Property(x => x.Id);
            modelBuilder.Entity<Message>().Property(x => x.Id);
        }
    }
}
