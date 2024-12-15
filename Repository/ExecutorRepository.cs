using Microsoft.EntityFrameworkCore;
using TaskMe.Data;
using TaskMe.Model;
using TaskMe.IRepository;
using System;

namespace TaskMe.Repository
{
    /// <summary>
    /// Репозиторий для работы с исполнителями.
    /// </summary>
    public class ExecutorRepository : ExecutorIRepository
    {
        private readonly TaskMeDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория исполнителей.
        /// </summary>
        /// <param name="context">Контекст базы данных для доступа к данным исполнителей.</param>
        public ExecutorRepository(TaskMeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает исполнителя по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор исполнителя.</param>
        /// <returns>Задача, содержащая исполнителя с указанным идентификатором.</returns>
        public async Task<Executor> GetExecutorById(int id)
        {
            return await _context.Executors.FirstOrDefaultAsync(c => c.ExecutorId == id);
        }

        /// <summary>
        /// Получает всех исполнителей.
        /// </summary>
        /// <param name="id">Идентификатор исполнителя (не используется в данном методе, возможно, ошибка).</param>
        /// <returns>Задача, содержащая список всех исполнителей.</returns>
        public async Task<IEnumerable<Executor>> GetAllExecutors(int id)
        {
            return await _context.Executors.ToListAsync();
        }

        /// <summary>
        /// Получает исполнителя по полному имени.
        /// </summary>
        /// <param name="FullName">Полное имя исполнителя.</param>
        /// <returns>Задача, содержащая исполнителя с указанным полным именем, или null, если исполнитель не найден.</returns>
        public async Task<Executor> GetExecutorByFullName(string FullName)
        {
            return await _context.Executors.FirstOrDefaultAsync(c => c.ExecutorName == FullName);
        }
    }
}
