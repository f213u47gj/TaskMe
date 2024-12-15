using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMe.Model;

namespace TaskMe.IRepository
{
    public interface RequestIRepository
    {
        Task<Request> GetRequsetById(int id);
        Task<IEnumerable<Request>> GetRequests();
        Task AddRequest(Request request);
        Task RemoveRequest(Request request);
        Task UpdateRequest(Request request);
    }
}
