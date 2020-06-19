using BigSchool_PHN.Models;
using BigSchool_PHN.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool_PHN.Controllers
{

    public class CourseController : Controller
    {
        private readonly ApplicationDbContex _dbContext;
        
        public CourseController()
        {
            _dbContext = new ApplicationDbContex();
        }
        
        // GET: Course
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place,
            };
            return RedirectToAction("Index","Home");
        }
    }
}