using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMe.Model;

namespace TaskMe.IRepository
{
    public interface StatusIRepository
    {
        Task<Status> GetStatusById(int id);
        Task<IEnumerable<Status>> GetStatuses();
    }
}
