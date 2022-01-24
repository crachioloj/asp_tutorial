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
      return Ok();
    }
  }
}