using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Random()
        {
            var movies = new Movie() {Name = "Shark!"};
            return View(movies);
        }
    }
}