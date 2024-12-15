using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMe.Model;

namespace TaskMe.IRepository
{
    /// <summary>
    /// Определяет методы для работы с сущностью Client.
    /// </summary>
    public interface ClientIRepository
    {
        /// <summary>
        /// Получает клиента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <returns>Объект Client.</returns>
        Task<Client> GetClientById(int id);

        /// <summary>
        /// Получает список всех клиентов.
        /// </summary>
        /// <param name="id">Идентификатор фильтра (если требуется).</param>
        /// <returns>Коллекция объектов Client.</returns>
        Task<IEnumerable<Client>> GetAllClients(int id);

        /// <summary>
        /// Получает клиента по его полному имени.
        /// </summary>
        /// <param name="FullName">Полное имя клиента.</param>
        /// <returns>Объект Client.</returns>
        Task<Client> GetClientByFullName(string FullName);
    }
}
