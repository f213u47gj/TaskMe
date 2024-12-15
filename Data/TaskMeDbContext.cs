using Microsoft.EntityFrameworkCore;
using TaskMe.Model;

namespace TaskMe.Data

{
    public class TaskMeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskMe;Integrated Security=True;Trust Server Certificate=False;");
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Executor> Executors { get; set; }
    }
}
