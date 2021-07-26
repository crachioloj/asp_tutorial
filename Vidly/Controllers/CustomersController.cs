using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
  public class CustomersController : Controller
  {
    private readonly List<Customer> _customers = new List<Customer>
      {
        new Customer { Id = 0, Name = "Mary Williams "},
        new Customer { Id = 1, Name = "John Smith"}
      };


    // GET: Customers
    public ActionResult Index()
    {
      return View(_customers);
    }

    [Route("customers/details/{id}")]
    public ActionResult Details(int id)
    {
      var customer = _customers.Where(c => c.Id == id).FirstOrDefault();

      if (customer != null)
      {
        return View(customer);
      }
      else
      {
        return HttpNotFound();
      }
    }
  }
}