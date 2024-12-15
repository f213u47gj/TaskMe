using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskMe.Model;

namespace TaskMe.IRepository
{
    /// <summary>
    /// Определяет методы для работы с сущностью Request.
    /// </summary>
    public interface RequestIRepository
    {
        /// <summary>
        /// Получает запрос по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор запроса.</param>
        /// <returns>Объект Request.</returns>
        Task<Request> GetRequsetById(int id);

        /// <summary>
        /// Получает список всех запросов.
        /// </summary>
        /// <returns>Коллекция объектов Request.</returns>
        Task<IEnumerable<Request>> GetRequests();

        /// <summary>
        /// Добавляет новый запрос.
        /// </summary>
        /// <param name="request">Объект Request для добавления.</param>
        Task AddRequest(Request request);

        /// <summary>
        /// Удаляет запрос.
        /// </summary>
        /// <param name="request">Объект Request для удаления.</param>
        Task RemoveRequest(Request request);

        /// <summary>
        /// Обновляет существующий запрос.
        /// </summary>
        /// <param name="request">Объект Request для обновления.</param>
        Task UpdateRequest(Request request);
    }
}
