using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockScissorsPaper.Controllers;
using RockScissorsPaper.Services;

namespace RockScissorsPaper.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ShouldReturnTheDefaultView()
        {
            HomeController controller = new HomeController(null);
            ViewResult result = (ViewResult) controller.Index();
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void Rock_TheComputherShouldThrowItsSymbol()
        {
            Mock<IBoard> board = new Mock<IBoard>();
            HomeController controller = new HomeController(board.Object);
            controller.Rock();
            
            board.Verify(b => b.PlayRock());
        }

        [TestMethod]
        public void Rock_UserWin_ShouldReturnUserWinView()
        {
            Mock<IBoard> board = new Mock<IBoard>();
            board.Setup(b => b.PlayRock()).Returns(Winner.User);
            HomeController controller = new HomeController(board.Object);
            PartialViewResult result = (PartialViewResult) controller.Rock();
            Assert.AreEqual(result.ViewName, "UserWin");
        }
    }
}
