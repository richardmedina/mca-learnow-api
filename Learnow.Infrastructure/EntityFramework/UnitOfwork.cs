using Learnow.Domain;
using Learnow.Domain.Repositories;
using Learnow.Infrastructure.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Infrastructure.EntityFramework
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfwork(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IUserRepository GetUserRepository()
        {
            return new UserRepository(_context);
        }
    }
}
