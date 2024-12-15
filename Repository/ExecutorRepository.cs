using Microsoft.EntityFrameworkCore;
using TaskMe.Data;
using TaskMe.Model;
using TaskMe.IRepository;
using System;

namespace TaskMe.Repository
{
    public class ExecutorRepository : ExecutorIRepository
    {
        private readonly TaskMeDbContext _context;

        public ExecutorRepository(TaskMeDbContext context)
        {
            _context = context;
        }

        public async Task<Executor> GetExecutorById(int id)
        {
            return await _context.Executors.FirstOrDefaultAsync(c => c.ExecutorId == id);
        }

        public async Task<IEnumerable<Executor>> GetAllExecutors(int id)
        {
            return await _context.Executors.ToListAsync();
        }

        public async Task<Executor> GetExecutorByFullName(string FullName)
        {
            return await _context.Executors.FirstOrDefaultAsync(c => c.ExecutorName == FullName);
        }
    }
}
