using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SC.Model;
using SC.Repository;

namespace SC.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;

        protected EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            UnitOfWork = unitOfWork;
            _repository = repository;
        }

        protected IUnitOfWork UnitOfWork { get; }

        public virtual void Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Add(entity);
            UnitOfWork.Commit();
        }


        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Edit(entity);
            UnitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Delete(entity);
            UnitOfWork.Commit();
        }

        public T GetById(object id)
        {
            return _repository.GetById(id);
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return _repository.GetAll(predicate);
        }
    }
}
