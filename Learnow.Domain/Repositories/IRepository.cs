using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learnow.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetById(long id);
        Task Delete();
        Task Update(TEntity entity);
    }
}
