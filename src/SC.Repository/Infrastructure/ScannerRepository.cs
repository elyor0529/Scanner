using System.Data.Entity;
using System.Linq;
using SC.Model.Entity;

namespace SC.Repository.Infrastructure
{
    public class ScannerRepository : GenericRepository<Scanner>, IScannerRepository
    {
        public ScannerRepository(DbContext context)
              : base(context)
        {

        }
         
    }
}
