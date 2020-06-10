using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ViewResult Index()
        {
            var movies = GetAllMovies();
            return View(movies);
        }

        public ActionResult Random()
        {
            var movies = new Movie() { Name = "Shark!" };
            var customer = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };
            var viewModel = new RandomViewModel
            {
                Movie = movies,
                Customers = customer
            };
            return View(viewModel);
        }

        private List<Movie> GetAllMovies()
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name = "Shark!"},
                new Movie {Id = 2, Name = "Hulk"}
            };
            return movies;
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(String.Format("pageIndex = {0} & sortBy = {1}", pageIndex, sortBy));
        //}
    }
}