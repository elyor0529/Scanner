using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SC.Model.Entity;
using SC.Repository;
using SC.Repository.Infrastructure;
using SC.Service.Infrastructure;

namespace SC.Test.Services
{
    [TestClass]
    public class ScannerServiceTest
    {
        private List<Scanner> _list;
        private Mock<ITupleItemRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitWork;
        private ITupleItemService _service;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ITupleItemRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new TupleItemService(_mockUnitWork.Object, _mockRepository.Object);
            _list = new List<Scanner>
            {
                new Scanner {Id = 1, Name = "RT"},
                new Scanner {Id = 2, Name = "LG"},
                new Scanner {Id = 3, Name = "GT"}
            };
        }
    }
}