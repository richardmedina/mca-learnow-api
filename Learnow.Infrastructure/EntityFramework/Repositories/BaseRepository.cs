using Learnow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Infrastructure.EntityFramework.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;
        internal BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>()
                .FirstOrDefaultAsync(expression);
        }

        public Task<TEntity> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
