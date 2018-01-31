using SC.Model.Entity;
using SC.Repository;
using SC.Repository.Infrastructure;

namespace SC.Service.Infrastructure
{
    public class TupleItemService : EntityService<TupleItem>, ITupleItemService
    {
        private readonly ITupleItemRepository _repository;

        public TupleItemService(IUnitOfWork unitOfWork, ITupleItemRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        }
         
    }
}
