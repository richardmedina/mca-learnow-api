using Learnow.Domain.Entities;
using Learnow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Infrastructure.EntityFramework.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        internal UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserEntity>> GetTwoElements()
        {
            throw new NotImplementedException();
        }
    }
}
