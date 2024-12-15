using Microsoft.EntityFrameworkCore;
using TaskMe.Data;
using TaskMe.Model;
using TaskMe.IRepository;

namespace TaskMe.Repository
{
    public class RequestRepository : RequestIRepository
    {
        private readonly TaskMeDbContext _context;

        public RequestRepository(TaskMeDbContext context)
        {
            _context = context;
        }

        public async Task<Request> GetRequsetById(int id)
        {
            return await _context.Requests
                .Include(r => r.Status)
                .Include(r => r.Client)
                .Include(r => r.Executor)
                .FirstOrDefaultAsync(s => s.RequestId == id);
        }

        public async Task<IEnumerable<Request>> GetRequests()
        {
            var requests = await _context.Requests
                .Include(r => r.Status)
                .Include(r => r.Client)
                .Include(r => r.Executor)
                .OrderByDescending(r => r.UpdateAt)
                .ToListAsync();

            return requests;
        }

        public async Task AddRequest(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRequest(Request request)
        {
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRequest(Request request)
        {
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
        }
    }
}
