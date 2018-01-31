using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SC.Model;

namespace SC.Service
{
    public interface IEntityService<T> : IService
     where T : BaseEntity
    {

        void Create(T entity);

        void Delete(T entity);

        T GetById(object id);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
          
        void Update(T entity);

    }
}
