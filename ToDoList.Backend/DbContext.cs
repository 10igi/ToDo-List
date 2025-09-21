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

            modelBuilder.Entity<Task>()
                .HasOne(l => l.List)
                .WithMany(t => t.Tasks)
                .HasForeignKey(l => l.ListId);


            modelBuilder.Entity<Task>()
                .HasMany(st => st.Subtasks)
                .WithOne(t => t.Task)
                .HasForeignKey(st => st.TaskId);

            modelBuilder.Entity<Subtask>()
                .HasOne(t => t.Task)
                .WithMany(st => st.Subtasks)
                .HasForeignKey(st => st.TaskId);


            modelBuilder.Entity<Task>()
                .HasMany(tt => tt.TaskTags)
                .WithMany(t => t.Task)
                .HasForeignKey(tt => tt.TaskId);

            modelBuilder.Entity<TaskTag>()
                .HasMany(t => t.Task)
                .WithMany(tt => tt.TaskTag)
                .HasForeignKey(tt => tt.TaskId);


            modelBuilder.Entity<Tag>()
                .HasMany(tg => tg.Tags)
                .WithMany(tt => tt.TaskTags)
                .HasForeignKey(tt => tt.TagId);

            modelBuilder.Entity<TaskTag>()
                 .HasMany(t => t.Tag)
                 .WithMany(tt => tt.TaskTag)
                 .HasForeignKey(tt => tt.TagId);
        }
    }
}
