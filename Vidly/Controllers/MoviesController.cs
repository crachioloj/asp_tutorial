using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
  public class MoviesController : Controller
  {
    private readonly ApplicationDbContext  _dbContext;

    public MoviesController()
    {
      _dbContext = new ApplicationDbContext ();
    }

    protected override void Dispose(bool disposing)
    {
      _dbContext.Dispose();
      base.Dispose(disposing);
    }

    public ViewResult Index()
    {
      if (User.IsInRole(RoleName.CanManageMovies))
      {
        return View("List");
      }

      return View("ReadOnlyList");
    }

    [Authorize(Roles = RoleName.CanManageMovies)]
    public ActionResult New()
    {
      var viewModel = new MovieFormViewModel
      {
        Genres = _dbContext.Genres.AsEnumerable()
      };

      return View("MovieForm", viewModel);
    }

    [Route("movies/details/{id}")]
    public ActionResult Details(int id)
    {
      var movie = _dbContext.Movies
        .Include(m => m.Genre)
        .Where(m => m.Id == id)
        .FirstOrDefault();

      if (movie != null)
      {
        return View(movie);
      }

      return HttpNotFound();
    }

    [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
    public ActionResult ByReleaseYear(int year, int month)
    {
      return Content(year + "/" + month);
    }


    public ActionResult Edit(int id)
    {
      var dbMovie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);

      if (dbMovie == null)
      {
        return HttpNotFound();
      }

      var viewModel = new MovieFormViewModel(dbMovie)
      {
        Genres = _dbContext.Genres.AsEnumerable()
      };

      return View("MovieForm", viewModel);
    }

    [HttpPost]
    public ActionResult Save(Movie movie)
    {
      if (!ModelState.IsValid)
      {
        var viewModel = new MovieFormViewModel(movie)
        {
          Genres = _dbContext.Genres.ToList(),
        };
        return View("MovieForm", viewModel);
      }

      if (movie.Id == 0)
      {
        movie.DateAdded = DateTime.Now;
        _dbContext.Movies.Add(movie);
      }
      else
      {
        var dbMovie = _dbContext.Movies.SingleOrDefault(m => m.Id == movie.Id);
        if (dbMovie == null)
        {
          return HttpNotFound();
        }
        dbMovie.GenreId = movie.GenreId;
        dbMovie.Name = movie.Name;
        dbMovie.NumberInStock = movie.NumberInStock;
        dbMovie.ReleaseDate = movie.ReleaseDate;
      }

      try
      {
        _dbContext.SaveChanges();
      }
      catch (DbEntityValidationException e)
      {
        Console.WriteLine(e);
      }

      return RedirectToAction("Index", "Movies");
    }
  }
}