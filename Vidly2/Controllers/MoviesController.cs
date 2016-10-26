using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _MovieContext;

        public MoviesController()
        {
            _MovieContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk!" };
            var customers = new List<Customer>
            {

                new Customer() { Name = "Customer 1"},
                new Customer() { Name = "Customer 2"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        // GET: Movies/Edit/{id}
        public ActionResult Edit(int id)
        {
            return Content("id="+id);
        }

        // GET: /Movies
        public ActionResult Index()
        {
            var movies = _MovieContext.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        // GET: Customers/Details/{id}
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var movies = _MovieContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }

        //private IEnumerable<Movie> GetMovie()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie() { Id = 1, Name = "Shrek" },
        //        new Movie() { Id = 2, Name = "Wall-e" }
        //    };
        //}
    }
}