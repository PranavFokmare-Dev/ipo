using Contracts.Repository;
using ipo.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Entitites;
using Entitites.Models;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : IEntity
    {
        protected ApplicationContext  context { get; set; }
        public RepositoryBase(ApplicationContext context)
        {
           this.context = context;
        }
        public void Create(T entity) 
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return context.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> search)
        {
            return context.Set<T>().Where(search);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public async Task<bool> Exists(Guid id)
        {
            return await context.Set<T>().AnyAsync(t => t.Id == id);
        }
    }
}
