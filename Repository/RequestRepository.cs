using Microsoft.EntityFrameworkCore;
using TaskMe.Data;
using TaskMe.Model;
using TaskMe.IRepository;

namespace TaskMe.Repository
{
    /// <summary>
    /// Репозиторий для работы с запросами.
    /// </summary>
    public class RequestRepository : RequestIRepository
    {
        private readonly TaskMeDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр репозитория запросов.
        /// </summary>
        /// <param name="context">Контекст базы данных для доступа к данным запросов.</param>
        public RequestRepository(TaskMeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает запрос по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор запроса.</param>
        /// <returns>Задача, содержащая запрос с указанным идентификатором, включая информацию о статусе, клиенте и исполнителе.</returns>
        public async Task<Request> GetRequsetById(int id)
        {
            return await _context.Requests
                .Include(r => r.Status)    // Включает информацию о статусе запроса
                .Include(r => r.Client)    // Включает информацию о клиенте запроса
                .Include(r => r.Executor)  // Включает информацию о исполнителе запроса
                .FirstOrDefaultAsync(s => s.RequestId == id); // Ищет запрос по идентификатору
        }

        /// <summary>
        /// Получает все запросы, отсортированные по дате обновления (по убыванию).
        /// </summary>
        /// <returns>Задача, содержащая список всех запросов с подробной информацией о статусе, клиенте и исполнителе.</returns>
        public async Task<IEnumerable<Request>> GetRequests()
        {
            var requests = await _context.Requests
                .Include(r => r.Status)    // Включает информацию о статусе запроса
                .Include(r => r.Client)    // Включает информацию о клиенте запроса
                .Include(r => r.Executor)  // Включает информацию о исполнителе запроса
                .OrderByDescending(r => r.UpdateAt) // Сортирует запросы по дате обновления (по убыванию)
                .ToListAsync(); // Извлекает список запросов

            return requests;
        }

        /// <summary>
        /// Добавляет новый запрос в базу данных.
        /// </summary>
        /// <param name="request">Запрос, который нужно добавить.</param>
        /// <returns>Задача, которая завершится после добавления запроса в базу данных.</returns>
        public async Task AddRequest(Request request)
        {
            await _context.Requests.AddAsync(request); // Добавляет запрос в контекст
            await _context.SaveChangesAsync(); // Сохраняет изменения в базе данных
        }

        /// <summary>
        /// Удаляет запрос из базы данных.
        /// </summary>
        /// <param name="request">Запрос, который нужно удалить.</param>
        /// <returns>Задача, которая завершится после удаления запроса из базы данных.</returns>
        public async Task RemoveRequest(Request request)
        {
            _context.Requests.Remove(request); // Удаляет запрос из контекста
            await _context.SaveChangesAsync(); // Сохраняет изменения в базе данных
        }

        /// <summary>
        /// Обновляет информацию о запросе в базе данных.
        /// </summary>
        /// <param name="request">Запрос, который нужно обновить.</param>
        /// <returns>Задача, которая завершится после обновления данных запроса в базе данных.</returns>
        public async Task UpdateRequest(Request request)
        {
            _context.Requests.Update(request); // Обновляет запрос в контексте
            await _context.SaveChangesAsync(); // Сохраняет изменения в базе данных
        }
    }
}
