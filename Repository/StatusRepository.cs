using Microsoft.EntityFrameworkCore;
using TaskMe.Data;
using TaskMe.Model;
using System;
using TaskMe.Model;
using TaskMe.IRepository;

namespace Requests.Repository
{
    public class StatusRepository : StatusIRepository
    {
        private readonly TaskMeDbContext _context;

        public StatusRepository(TaskMeDbContext context)
        {
            _context = context;
        }

        public async Task<Status> GetStatusById(int id)
        {
            return await _context.Statuses.FirstOrDefaultAsync(s => s.StatusId == id);
        }

        public async Task<IEnumerable<Status>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }
    }
}