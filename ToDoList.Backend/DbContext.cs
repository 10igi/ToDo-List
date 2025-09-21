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
            optionsBuilder.UseSqlite("Data Source=todolist.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>()
                .HasMany(l => l.Tasks)
                .WithOne(t => t.List)
                .HasForeignKey(t => t.ListId);

            //modelBuilder.Entity<TaskTag>()
            //    .HasKey(tt => new { tt.TaskId, tt.TagId });

            modelBuilder.Entity<Task>()
                .HasOne(l => l.List);
                //.WithMany(s => s.Subtasks)
                //.HasForeignKey(s => s.TaskId)
                //.WithMany(tt => tt.TaskTag)
                //.HasForeignKey(tt => tt.TaskId);

            //modelBuilder.Entity<Tag>()
            //    .HasMany(tg => tg.Tag)
            //    .WithMany(tt => tt.TaskTag)
            //    .HasForeignKey(tt => tt.TagId);

            //modelBuilder.Entity<Subtask>()
            //    .HasOne(s => s.Task)
            //    .WithMany(t => t.Subtasks)
            //    .HasForeignKey(s => s.TaskId);
        }
    }
}
