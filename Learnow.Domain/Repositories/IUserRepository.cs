using Learnow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<IEnumerable<UserEntity>> GetTwoElements();
    }
}
