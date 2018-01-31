using System.Data.Entity;
using System.Linq;
using SC.Model.Entity;

namespace SC.Repository.Infrastructure
{
    public class DataTupleRepository : GenericRepository<DataTuple>, IDataTupleRepository
    {
        public DataTupleRepository(DbContext context)
              : base(context)
        {

        } 
    }
}
