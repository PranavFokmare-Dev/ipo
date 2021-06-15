using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> search);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<bool> Exists(Guid id);
    }
}
