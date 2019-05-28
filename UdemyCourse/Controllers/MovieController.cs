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

            //other ways to send data to a view: view data dictionary but this way is fragile because if the view doesn't exists this string we get a null pointer reference and in the view we need to cast becouse  view data is a dynamic type
            ViewData["Movie"] = movie;
            //this way is better becouse is added in runtime which mean we don't get  compile time safety, but anyway,
            //the better form is pass into a return method 
            ViewBag.Movie = movie;
            var viewResult = new ViewResult();
            viewResult.ViewData.Model = movie;
            /*
             * so, where go the model when i return a view result?
             * var viewResult = new ViewResult();
             * viewResult.ViewData.Model = movie; -> the model is save in the Model property 
             */
            return View(movie);
        }

    }
}