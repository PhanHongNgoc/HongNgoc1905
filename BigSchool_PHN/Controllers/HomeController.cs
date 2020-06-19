using BigSchool_PHN.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool_PHN.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContex _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContex();
        }
        public ActionResult Index()
        {
            var upcomingCourses = _dbContext.Courses
                .Include (c => c.Lecturer)
                .Include(c => c.Category)
                .Where(c => c.DateTime > DateTime.Now);
            return View(upcomingCourses);
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