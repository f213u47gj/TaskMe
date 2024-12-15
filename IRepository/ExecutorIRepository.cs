using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskMe.Model;

namespace TaskMe.IRepository
{
    /// <summary>
    /// Определяет методы для работы с сущностью Executor.
    /// </summary>
    public interface ExecutorIRepository
    {
        /// <summary>
        /// Получает исполнителя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор исполнителя.</param>
        /// <returns>Объект Executor.</returns>
        Task<Executor> GetExecutorById(int id);

        /// <summary>
        /// Получает список всех исполнителей.
        /// </summary>
        /// <param name="id">Идентификатор фильтра (если требуется).</param>
        /// <returns>Коллекция объектов Executor.</returns>
        Task<IEnumerable<Executor>> GetAllExecutors(int id);

        /// <summary>
        /// Получает исполнителя по его полному имени.
        /// </summary>
        /// <param name="FullName">Полное имя исполнителя.</param>
        /// <returns>Объект Executor.</returns>
        Task<Executor> GetExecutorByFullName(string FullName);
    }
}
