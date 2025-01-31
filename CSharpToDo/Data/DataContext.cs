using CSharpToDo.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpToDo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public string DbPath { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var baseDirectory = AppContext.BaseDirectory;
            var dataFolder = System.IO.Path.Combine(baseDirectory, "Data");

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            DbPath = System.IO.Path.Combine(dataFolder, "todos.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
