using BigSchool_PHN.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BigSchool_PHN.Controllers.AttendancesController;

namespace BigSchool_PHN.Controllers
{
    public class AttendancesController : Controller
    {
        // GET: Attendances
        private ApplicationDbContex _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContex();
        }
        [HttpPost]
        public HttpActionResult Attend ([FromBody] int courseId)
        {
            var attendance = new Attendance
            {
                CourseId = courseId,
                AttendeeId = User.Identity.GetUserId()
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return OK();
        }

        private HttpActionResult OK()
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            return View();
        }

        public class HttpActionResult
        {
        }
    }

    internal class FromBodyAttribute : Attribute
    {
    }
}