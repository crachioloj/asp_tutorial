using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
  public class RentalsController : ApiController
  {
    private ApplicationDbContext _dbContext;

    public RentalsController()
    {
      _dbContext = new ApplicationDbContext();
    }

    public IHttpActionResult GetRentals()
    {
      var rentalDtos = _dbContext.Rentals
        //.Include(r => r)
        .AsEnumerable()
        .Select(Mapper.Map<Rental, RentalDto>);

      return Ok(rentalDtos);
    }

    [HttpPost]
    public IHttpActionResult CreateNewRentals(RentalDto newRental)
    {
      if (!newRental.MovieIds.Any())
      {
        return BadRequest("No movie IDs have been found.");
      }

      var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
      if (customer is null)
      {
        return BadRequest("Customer not found.");
      }

      var movies = _dbContext.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

      if (movies.Count() != newRental.MovieIds.Count())
      {
        return BadRequest("One or more movie IDs are invalid.");
      }

      foreach (var movie in movies)
      {
        if (movie.NumberAvailable <= 0)
        {
          return BadRequest("Movie unavailable.");
        }

        movie.NumberAvailable--;

        var rental = new Rental
        {
          Customer = customer,
          Movie = movie,
          DateRented = DateTime.Now
        };
        _dbContext.Rentals.Add(rental);
      }

      _dbContext.SaveChanges();

      return Ok();
    }
  }
}