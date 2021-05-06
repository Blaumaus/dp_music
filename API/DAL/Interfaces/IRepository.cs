using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(string id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, Boolean>> predicate);
        void Create(TEntity entity);
        void Update(TEntity enity);
        void Delete(string id);
    }
}
