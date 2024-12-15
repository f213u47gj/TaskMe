using Microsoft.EntityFrameworkCore;
using TaskMe.Model;

namespace TaskMe.Data
{
    /// <summary>
    /// Представляет контекст базы данных для приложения TaskMe.
    /// Обеспечивает доступ к базе данных TaskMe и её сущностям.
    /// </summary>
    public class TaskMeDbContext : DbContext
    {
        /// <summary>
        /// Конфигурирует параметры подключения к базе данных.
        /// </summary>
        /// <param name="optionsBuilder">Объект для настройки параметров контекста базы данных.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskMe;Integrated Security=True;Trust Server Certificate=False;");
        }

        /// <summary>
        /// Получает или задаёт DbSet для сущности Status.
        /// </summary>
        public DbSet<Status> Statuses { get; set; }

        /// <summary>
        /// Получает или задаёт DbSet для сущности Request.
        /// </summary>
        public DbSet<Request> Requests { get; set; }

        /// <summary>
        /// Получает или задаёт DbSet для сущности Client.
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Получает или задаёт DbSet для сущности Executor.
        /// </summary>
        public DbSet<Executor> Executors { get; set; }
    }
}
