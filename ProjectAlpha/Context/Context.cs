using Microsoft.EntityFrameworkCore;
using ProjectAlpha.Entities;

namespace ProjectAlpha.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        {


        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Message>().Property(x => x.Id);
            modelBuilder.Entity<Project>().Property(x => x.Id);
            modelBuilder.Entity<Project>().HasMany(x => x.Activities);
            modelBuilder.Entity<Staff>().Property(x => x.Id);
            modelBuilder.Entity<Activity>().Property(x => x.Id);
        }
    }
}
