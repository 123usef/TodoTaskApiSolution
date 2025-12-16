using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoTaskApi.Models;

namespace TodoTaskApi.Context
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                
        }

        public DbSet<TodoTask> todoTasks { get; set; }
        public DbSet<TaskCategory> taskCategories { get; set; }
    }

}
