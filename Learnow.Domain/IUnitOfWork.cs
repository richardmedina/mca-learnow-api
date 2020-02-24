using Learnow.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Domain
{
    public interface IUnitOfWork
    {
        IUserRepository GetUserRepository();
        Task<int> CommitAsync();
    }
}
