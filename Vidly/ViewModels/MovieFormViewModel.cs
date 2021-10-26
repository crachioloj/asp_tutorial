using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
  public class MovieFormViewModel
  {
    public MovieFormViewModel()
    {
      Id = 0;
    }

    public MovieFormViewModel(Movie movie)
    {
      Id = movie.Id;
      Name = movie.Name;
      GenreId = movie.GenreId;
      ReleaseDate = movie.ReleaseDate;
      NumberInStock = movie.NumberInStock;
    }

    public IEnumerable<Genre> Genres { get; set; }

    public int? Id { get; set; }
    public string Title => (Id != 0) ? "Edit Movie" : "New Movie";

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Genre")]
    public int? GenreId { get; set; }

    [Required]
    [Display(Name = "Release Date")]
    public DateTime? ReleaseDate { get; set; }

    [Required]
    //[Range(1, 20)]
    [MovieStock0To20]
    [Display(Name = "Number In Stock")]
    public int? NumberInStock { get; set; }
  }
}