using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyCourse.Models;

namespace UdemyCourse.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            Movie movie = new Movie() {Name = "Matrix"};
            //return View(movie);
            //return Content("hello world);
            //return HttpNotFound();
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new {page = 1, sortBy="name" });
            /*
             * This is the most used return types in controllers
             * Content return a stream
             * httpNotFound return a 404 http status
             * empty return a empty page
             * redirectToAction return a redirection to specific controller, third argument is a get parameter response
             */
        }
    }
}