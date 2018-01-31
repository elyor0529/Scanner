using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SC.Model.Entity;
using SC.Service;
using SC.Service.Infrastructure;
using SC.Web.Controllers;

namespace SC.Test.Controllers
{
    [TestClass]
    public class ScannerControllerTest
    {
        private ScannerController _controller; 
        private Mock<IScannerService> _serviceMock;

        [TestInitialize]
        public void Initialize()
        {
            _serviceMock = new Mock<IScannerService>();
            _controller = new ScannerController(_serviceMock.Object); 
        }
         
    }
}