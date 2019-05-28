using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UdemyCourse
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // to map custom routes, map first the most specific, later most generic
            /*
              * Custom route. the parameters type with curly blackets <{}>
             * regular expressions are the forth argument
             * that regex mean: year is a digit and the numvber in curly brackets are the number of repetitions
             * if the regex don't match, mvc return 404 error
             * if we want to specific date only we do: new { year = @"2015|2016", month = @"\d{2}"});
              */
            /*
             * Atribute routes: this aproach is very weak becouse if we change the action method name,
             * we need to open this file and change the action, atribute routes uses a annotation upper the method
             */
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();//activate the atribute route,now go to the action method
            /*routes.MapRoute(
                name:"MoviesByReleaseDate",
                url:"movie/released/{year}/{month}",
                defaults:new {controller = "Movie", action = "ByReleaseDate"},
                new { year = @"\d{4}", month = @"\d{2}"});*/
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
