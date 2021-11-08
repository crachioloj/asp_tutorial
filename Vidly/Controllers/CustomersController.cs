using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
  public class CustomersController : Controller
  {
    private readonly ApplicationDbContext  _dbContext;

    public CustomersController()
    {
      _dbContext = new ApplicationDbContext ();
    }

    protected override void Dispose(bool disposing)
    {
      _dbContext.Dispose();
      base.Dispose(disposing);
    }

    // GET: Customers
    public ActionResult Index()
    {
      return View();
    }

    [Route("customers/details/{id}")]
    public ActionResult Details(int id)
    {
      var customer = _dbContext.Customers
        .Include(c => c.MembershipType)
        .Where(c => c.Id == id)
        .FirstOrDefault();

      if (customer != null)
      {
        return View(customer);
      }

      return HttpNotFound();
    }

    public ActionResult New()
    {
      var membershipTypes = _dbContext.MembershipTypes.AsEnumerable();
      var viewModel = new CustomerFormViewModel { MembershipTypes = membershipTypes, Customer = new Customer() };
      return View("CustomerForm", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(Customer customer)
    {
      if (!ModelState.IsValid)
      {
        var viewModel = new CustomerFormViewModel
        {
          Customer = customer,
          MembershipTypes = _dbContext.MembershipTypes.ToList(),
        };

        return View("CustomerForm", viewModel);
      }

      if (customer.Id == 0)
      {
        _dbContext.Customers.Add(customer);
      }
      else
      {
        var dbCustomer = _dbContext.Customers.SingleOrDefault(c => c.Id == customer.Id);
        if (dbCustomer == null)
        {
          return HttpNotFound();
        }
        dbCustomer.DateOfBirth = customer.DateOfBirth;
        dbCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
        dbCustomer.MembershipTypeId = customer.MembershipTypeId;
        dbCustomer.Name = customer.Name;
      }

      try
      {
        _dbContext.SaveChanges();
      }
      catch (DbEntityValidationException e)
      {
        Console.WriteLine(e);
      }

      return RedirectToAction("Index", "Customers");
    }

    public ActionResult Edit(int id)
    {
      var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
      if (customer == null)
      {
        return HttpNotFound();
      }

      var viewModel = new CustomerFormViewModel
      {
        Customer = customer,
        MembershipTypes = _dbContext.MembershipTypes.AsEnumerable()
      };

      return View("CustomerForm", viewModel);
    }
  }
}