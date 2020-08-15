using Application.Commons;
using Application.DTO;
using Application.UserApplication.Query;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtAirTechExam.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IQuery<UserDTO> getUserViaAspeNetIdQuery;

        public HomeController()
        {
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            getUserViaAspeNetIdQuery = new GetUserViaAspNetIdQuery(userId);
            var HomeViewModel = getUserViaAspeNetIdQuery.ExecuteQuery();
            return View(HomeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}