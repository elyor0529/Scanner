using System.Data.Common;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SC.Model;
using SC.Model.Entity;
using SC.Repository;
using SC.Repository.Infrastructure;

namespace SC.Test.Repositories
{
    [TestClass]
    public class ScannerRepositoryTest
    {
        private StorageDbContext _databaseDbContext;
        private TupleItemRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _databaseDbContext = new StorageDbContext(); 
            _repository = new TupleItemRepository(_databaseDbContext); 
        }

    }
}
