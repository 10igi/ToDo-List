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
            #region List-Task
            modelBuilder.Entity<List>()
                .HasMany(l => l.Tasks)
                .WithOne(t => t.List)
                .HasForeignKey(t => t.ListId);

            modelBuilder.Entity<Task>()
                .HasOne(l => l.List)
                .WithMany(t => t.Tasks)
                .HasForeignKey(l => l.ListId);
            #endregion

            #region Task-Subtask
            modelBuilder.Entity<Task>()
                .HasMany(st => st.Subtasks)
                .WithOne(t => t.Task)
                .HasForeignKey(st => st.TaskId);

            modelBuilder.Entity<Subtask>()
                .HasOne(t => t.Task)
                .WithMany(st => st.Subtasks)
                .HasForeignKey(st => st.TaskId);
            #endregion

            #region Task-TaskTags-Tags
            modelBuilder.Entity<TaskTag>()
            .HasKey(tt => new { tt.TaskId, tt.TagId });

            #region Task-TaskTags
            //modelBuilder.Entity<Task>()
            //    .HasMany(tt => tt.TaskTags)
            //    .WithMany(t => t.Tasks)
            //    .HasForeignKey(tt => tt.TaskId);

            modelBuilder.Entity<TaskTag>()
                .HasOne(t => t.Task)
                .WithMany(tt => tt.TaskTags)
                .HasForeignKey(tt => tt.TaskId);
            #endregion

            #region Tag-TaskTag
            //modelBuilder.Entity<Tag>()
            //    .HasMany(tg => tg.Tag)
            //    .WithMany(tt => tt.TaskTags)
            //    .HasForeignKey(tt => tt.TagId);

            modelBuilder.Entity<TaskTag>()
                 .HasOne(t => t.Tag)
                 .WithMany(tt => tt.TaskTags)
                 .HasForeignKey(tt => tt.TagId);
            #endregion
            #endregion
        }
    }
}
