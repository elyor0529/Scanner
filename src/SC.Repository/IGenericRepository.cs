using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SC.Model;

namespace SC.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
         
        T GetById(object id);

        T Add(T entity);

        T Delete(T entity);

        void Edit(T entity);

        void Save();

    }
}
