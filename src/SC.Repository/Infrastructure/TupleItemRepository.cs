using System.Data.Entity;
using System.Linq;
using SC.Model.Entity;

namespace SC.Repository.Infrastructure
{
    public class TupleItemRepository : GenericRepository<TupleItem>, ITupleItemRepository
    {

        public TupleItemRepository(DbContext context)
              : base(context)
        {

        }
         
    }
}
