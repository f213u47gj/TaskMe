using Microsoft.EntityFrameworkCore;
using TaskMe.Data;
using TaskMe.Model;
using System;
using TaskMe.Model;
using TaskMe.IRepository;

namespace Requests.Repository
{
    /// <summary>
    /// Репозиторий для работы со статусами.
    /// </summary>
    public class StatusRepository : StatusIRepository
    {
        private readonly TaskMeDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория для работы со статусами.
        /// </summary>
        /// <param name="context">Контекст базы данных для доступа к данным статусов.</param>
        public StatusRepository(TaskMeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает статус по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор статуса.</param>
        /// <returns>Задача, содержащая статус с указанным идентификатором.</returns>
        public async Task<Status> GetStatusById(int id)
        {
            return await _context.Statuses.FirstOrDefaultAsync(s => s.StatusId == id);
        }

        /// <summary>
        /// Получает все статусы.
        /// </summary>
        /// <returns>Задача, содержащая список всех статусов.</returns>
        public async Task<IEnumerable<Status>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }
    }
}
