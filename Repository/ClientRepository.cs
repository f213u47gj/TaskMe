using Microsoft.EntityFrameworkCore;
using TaskMe.Data;
using TaskMe.Model;
using TaskMe.IRepository;
using System;

namespace TaskMe.Repository
{
    /// <summary>
    /// Репозиторий для работы с клиентами.
    /// </summary>
    public class ClientRepository : ClientIRepository
    {
        private readonly TaskMeDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория клиентов.
        /// </summary>
        /// <param name="context">Контекст базы данных для доступа к данным клиентов.</param>
        public ClientRepository(TaskMeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает клиента по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <returns>Задача, содержащая клиента с указанным идентификатором.</returns>
        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
        }

        /// <summary>
        /// Получает всех клиентов.
        /// </summary>
        /// <param name="id">Идентификатор клиента (не используется в данном методе, возможно, ошибка).</param>
        /// <returns>Задача, содержащая список всех клиентов.</returns>
        public async Task<IEnumerable<Client>> GetAllClients(int id)
        {
            return await _context.Clients.ToListAsync();
        }

        /// <summary>
        /// Получает клиента по полному имени (имя и фамилия).
        /// </summary>
        /// <param name="FullName">Полное имя клиента в формате "Имя Фамилия".</param>
        /// <returns>Задача, содержащая клиента с указанным полным именем, или null, если клиент не найден.</returns>
        public async Task<Client> GetClientByFullName(string FullName)
        {
            var names = FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (names.Length == 2)
            {
                return await _context.Clients
                    .FirstOrDefaultAsync(c => c.FirstName == names[0] && c.SecondName == names[1]);
            }

            return null;
        }
    }
}
