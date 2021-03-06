using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
  public class Movie
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    public Genre Genre { get; set; }

    [Required]
    [Display(Name = "Genre")]
    public int GenreId { get; set; }

    [Required]
    [Display(Name="Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [Display(Name = "Date Added")]
    public DateTime DateAdded { get; set; }

    [Required]
    [Display(Name = "Number In Stock")]
    public int NumberInStock { get; set; }

    public byte NumberAvailable { get; set; }

    public static readonly byte MinStock = 1;
    public static readonly byte MaxStock = 20;
  }
}