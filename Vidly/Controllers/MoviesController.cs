using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
  public class MoviesController : Controller
  {
    private readonly ApplicationDataModel _dataModel;

    public MoviesController()
    {
      _dataModel = new ApplicationDataModel();
    }

    protected override void Dispose(bool disposing)
    {
      _dataModel.Dispose();
      base.Dispose(disposing);
    }

    public ActionResult Index()
    {
      var movies = _dataModel.Movies
        .Include(m => m.Genre);

      return View(movies);
    }



    [Route("movies/details/{id}")]
    public ActionResult Details(int id)
    {
      var movie = _dataModel.Movies
        .Include(m => m.Genre)
        .Where(m => m.Id == id)
        .FirstOrDefault();

      if (movie != null)
      {
        return View(movie);
      }

      return HttpNotFound();
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