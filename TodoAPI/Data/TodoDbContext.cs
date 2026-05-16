using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Data
{
    public class TodoDbContext : DbContext  
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()"); // Use datetime('now') for SQLite

            modelBuilder.Entity<TodoItem>()
                .Property(t => t.IsCompleted)
                .HasDefaultValue(false);

            modelBuilder.Entity<TodoItem>()
                .Property(t => t.Priority)
                .HasDefaultValue("Medium");
        }
    }
}
