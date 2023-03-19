using Microsoft.AspNet.Identity;
using PhanPhuocThien_2011061063.Models;
using PhanPhuocThien_2011061063.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhanPhuocThien_2011061063.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public CoursesController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbcontext.Categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _dbcontext.Categories.ToList(); 
                return View("Create", viewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place,
            };
            _dbcontext.Courses.Add(course);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}