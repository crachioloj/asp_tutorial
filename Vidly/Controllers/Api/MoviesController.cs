using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
  public class MoviesController : ApiController
  {
    private ApplicationDataModel _dbContext;

    public MoviesController()
    {
      _dbContext = new ApplicationDataModel();
    }

    public IEnumerable<MovieDto> GetMovies()
    {
      return _dbContext.Movies.AsEnumerable().Select(Mapper.Map<Movie, MovieDto>);
    }

    [HttpGet]
    public IHttpActionResult GetMovie(int id)
    {
      var movie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
      if (movie is null)
      {
        return NotFound();
      }

      return Ok(Mapper.Map<Movie, MovieDto>(movie));
    }

    [HttpPost]
    public IHttpActionResult CreateMovie(MovieDto movieDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var movie = Mapper.Map<MovieDto, Movie>(movieDto);
      _dbContext.Movies.Add(movie);
      _dbContext.SaveChanges();

      movieDto.Id = movie.Id;

      return Created(new Uri($"{Request.RequestUri}/{movie.Id}"), movieDto);
    }

    [HttpPut]
    public void UpdateMovie(int id, MovieDto movieDto)
    {
      if (!ModelState.IsValid)
      {
        throw new HttpResponseException(HttpStatusCode.BadRequest);
      }

      var dbMovie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
      if (dbMovie is null)
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }

      Mapper.Map(movieDto, dbMovie);

      _dbContext.SaveChanges();
    }

    [HttpDelete]
    public void DeleteMovie(int id)
    {
      if (!ModelState.IsValid)
      {
        throw new HttpResponseException(HttpStatusCode.BadRequest);
      }

      var dbMovie = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
      if (dbMovie is null)
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }

      _dbContext.Movies.Remove(dbMovie);

      _dbContext.SaveChanges();
    }
  }
}
