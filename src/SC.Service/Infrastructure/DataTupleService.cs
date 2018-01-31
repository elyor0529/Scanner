using SC.Model.Entity;
using SC.Repository;
using SC.Repository.Infrastructure;

namespace SC.Service.Infrastructure
{
    public class DataTupleService : EntityService<DataTuple>, IDataTupleService
    {
        private readonly IDataTupleRepository _repository;

        public DataTupleService(IUnitOfWork unitOfWork, IDataTupleRepository repository)
            : base(unitOfWork, repository)
        {
            _repository = repository;
        } 
    }
}
