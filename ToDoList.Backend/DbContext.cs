using Microsoft.EntityFrameworkCore;

namespace ToDoList.Backend
{
    public class AppDbContext : DbContext
    {
        //Tables
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<List> Lists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Mobile.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
