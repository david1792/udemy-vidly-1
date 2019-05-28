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

        public ActionResult Edit(int id)
        {
            /*
             *if we open the route config, we see the default route,
             * url: "{controller}/{action}/{id}", the default route spected a parameter call id
             * if we change the name of this method, mvs response with an error e.g.
             *ActionResult Edit(int movieId)
             */
            //to test embebled parameter: https://localhost:44339/Movie/edit/1
            //to test query string parameter: https://localhost:44339/Movie/edit?id=1
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            //to test: https://localhost:44339/Movie?pageIndex=2&sortBy=release
            if (!pageIndex.HasValue)
                pageIndex = 0;
            if (string.IsNullOrEmpty(sortBy))
                sortBy = "name";
            return Content(string.Format("pageIndex={0} sortBy={1}", pageIndex, sortBy));
        }
        //atribute route, more powerful and we can specify constrains
        [Route("movie/released/{year:regex(\\d{4})}/{month:range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            /*
             * bad because missing parameters url :https://localhost:44339/movies/released
             * good url https://localhost:44339/movie/released/2015/02
             */
            return Content(year + "/" + month);
        }
    }
}