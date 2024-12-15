using Microsoft.EntityFrameworkCore;
using TaskMe.Data;
using TaskMe.Model;
using TaskMe.IRepository;
using System;

namespace TaskMe.Repository
{
    public class ClientRepository : ClientIRepository
    {
        private readonly TaskMeDbContext _context;

        public ClientRepository(TaskMeDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == id);
        }

        public async Task<IEnumerable<Client>> GetAllClients(int id)
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByFullName(string FullName)
        {
            var names = FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (names.Length == 2)
            {
                return await _context.Clients
                    .FirstOrDefaultAsync(c => c.FirstName == names[0] && c.SecondName == names[1]);
            }

            return null;
        }
    }
}
