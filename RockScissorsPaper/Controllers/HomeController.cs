using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RockScissorsPaper.Services;

namespace RockScissorsPaper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBoard _board;

        public HomeController(IBoard board)
        {
            _board = board;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rock()
        {
            _board.PlayRock();
            return PartialView("UserWin");
        }
    }
}
