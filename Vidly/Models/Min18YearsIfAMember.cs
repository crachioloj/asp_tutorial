using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
  public class Min18YearsIfAMember : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (!(validationContext.ObjectInstance is Customer customer))
      {
        return new ValidationResult("Customer is required.");
      }

      if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
      {
        return ValidationResult.Success;
      }

      if (customer.DateOfBirth is null)
      {
        return new ValidationResult("Birthdate is required.");
      }

      var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;

      return (age >= 18)
        ? ValidationResult.Success
        : new ValidationResult("Customer must be 18 years old or older.");
    }
  }
}