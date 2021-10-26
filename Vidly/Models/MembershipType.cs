 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
  public class MembershipType
  {
    [Key]
    public int Id { get; set; }

    public short SignUpFee { get; set; }

    public int DurationInMonths { get; set; }

    public int DiscountRate { get; set; }

    [StringLength(255)]
    public string Name { get; set; }

    public static readonly byte Unknown = 0;
    public static readonly byte PayAsYouGo = 1;

  }
}