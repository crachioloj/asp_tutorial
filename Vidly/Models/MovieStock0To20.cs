using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
  public class MovieStock0To20 : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (!(validationContext.ObjectInstance is Movie movie))
      {
        return new ValidationResult("Movie is required.");
      }

      return (movie.NumberInStock >= Movie.MinStock && movie.NumberInStock <= Movie.MaxStock)
        ? ValidationResult.Success
        : new ValidationResult($"Movie stock must be between {Movie.MinStock} and {Movie.MaxStock}.");
    }
  }
}