using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SC.Web.Controllers;

namespace SC.Test.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public async Task Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result =await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        } 
    }
}
