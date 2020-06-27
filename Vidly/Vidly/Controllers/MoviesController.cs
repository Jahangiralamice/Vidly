using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Linq;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var genreList = _context.Genres.ToList();
            var viewModel = new MovieViewModel
            {
                Genres = genreList
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View(viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(r => r.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View(viewModel);
            }
            var movieInDb = _context.Movies.Single(r => r.Id == movie.Id);

            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;
            //movieInDb.DateAdded = movie.DateAdded;
            movieInDb.NumberInStock = movie.NumberInStock;

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(r => r.Genre).SingleOrDefault(r => r.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
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

    }
}