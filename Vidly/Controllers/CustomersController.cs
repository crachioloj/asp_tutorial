using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
  public class CustomersController : Controller
  {
    private readonly ApplicationDataModel _dataModel;

    public CustomersController()
    {
      _dataModel = new ApplicationDataModel();
    }

    protected override void Dispose(bool disposing)
    {
      _dataModel.Dispose();
      base.Dispose(disposing);
    }

    // GET: Customers
    public ActionResult Index()
    {
      var customers = _dataModel.Customers
        .Include(c => c.MembershipType);

      return View(customers);
    }

    [Route("customers/details/{id}")]
    public ActionResult Details(int id)
    {
      var customer = _dataModel.Customers
        .Include(c => c.MembershipType)
        .Where(c => c.Id == id)
        .FirstOrDefault();

      if (customer != null)
      {
        return View(customer);
      }

      return HttpNotFound();
    }
  }
}