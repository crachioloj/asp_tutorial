﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
  public class CustomerDto
  {
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public bool IsSubscribedToNewsletter { get; set; }

    public int MembershipTypeId { get; set; }

    public MembershipTypeDto MembershipType { get; set; }

    //[Min18YearsIfAMember]
    public DateTime? DateOfBirth { get; set; }
  }
}