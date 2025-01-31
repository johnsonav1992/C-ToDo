using CSharpToDo.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpToDo.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Todo> Todos { get; set; }
    }
}
