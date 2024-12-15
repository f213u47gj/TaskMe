using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskMe.Model;

namespace TaskMe.IRepository
{
    /// <summary>
    /// Определяет методы для работы с сущностью Status.
    /// </summary>
    public interface StatusIRepository
    {
        /// <summary>
        /// Получает статус по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор статуса.</param>
        /// <returns>Объект Status.</returns>
        Task<Status> GetStatusById(int id);

        /// <summary>
        /// Получает список всех статусов.
        /// </summary>
        /// <returns>Коллекция объектов Status.</returns>
        Task<IEnumerable<Status>> GetStatuses();
    }
}
