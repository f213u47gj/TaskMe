using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMe.Model;

namespace TaskMe.IRepository
{
    public interface ClientIRepository
    {
        Task<Client> GetClientById(int id);
        Task<IEnumerable<Client>> GetAllClients(int id);
        Task<Client> GetClientByFullName(string FullName);
    }
}
