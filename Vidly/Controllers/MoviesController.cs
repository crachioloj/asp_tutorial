using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
  public class MoviesController : Controller
  {
    private readonly List<Movie> _movies = new List<Movie>()
      {
        new Movie { Id = 0, Name = "Shrek"},
        new Movie { Id = 1, Name = "Wall-E"}
      };

    public ActionResult Index()
    {
      return View(_movies);
    }

    // GET: Movies/Random
    public ActionResult Random()
    {
      var movie = new Movie() { Name = "Shrek" };
      var customers = new List<Customer>
      {
        new Customer { Id = 0, Name = "Customer 0"},
        new Customer { Id = 1, Name = "Customer 1"}
      };

      var viewModel = new RandomMovieViewModel
      {
        Movie = movie,
        Customers = customers
      };

      return View(viewModel);
    }

    public ActionResult Edit(int id)
    {
      return Content("id=" + id);
    }

    // Movies
    /*
    public ActionResult Index(int? pageIndex, string sortBy)
    {
      if (!pageIndex.HasValue)
      {
        pageIndex = 1;
      }

      if (string.IsNullOrWhiteSpace(sortBy))
      {
        sortBy = "Name";
      }

      return Content($"pageIndex={pageIndex}&sortyBy={sortBy}");
    }
    */

    [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
    public ActionResult ByReleaseYear(int year, int month)
    {
      return Content(year + "/" + month);
    }
  }
}