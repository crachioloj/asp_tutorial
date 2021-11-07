using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
  public class CustomersController : ApiController
  {
    private ApplicationDataModel _dbContext;

    public CustomersController()
    {
      _dbContext = new ApplicationDataModel();
    }

    public IHttpActionResult GetCustomers()
    {
      var customerDtos = _dbContext.Customers
        .Include(c => c.MembershipType)
        .AsEnumerable()
        .Select(Mapper.Map<Customer, CustomerDto>);

      return Ok(customerDtos);
    }

    [HttpGet]
    public IHttpActionResult GetCustomer(int id)
    {
      var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

      if (customer is null)
      {
        return NotFound();
      }

      return Ok(Mapper.Map<Customer, CustomerDto>(customer));
    }

    [HttpPost]
    public IHttpActionResult CreateCustomer(CustomerDto customerDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
      _dbContext.Customers.Add(customer);
      _dbContext.SaveChanges();

      customerDto.Id = customer.Id;

      return Created(new Uri($"{Request.RequestUri}/{customer.Id}"), customerDto);
    }

    [HttpPut]
    public void UpdateCustomer(int id, CustomerDto customerDto)
    {
      if (!ModelState.IsValid)
      {
        throw new HttpResponseException(HttpStatusCode.BadRequest);
      }

      var dbCustomer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
      if (dbCustomer is null)
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }

      Mapper.Map(customerDto, dbCustomer);

      _dbContext.SaveChanges();
    }

    [HttpDelete]
    public void DeleteCustomer(int id)
    {
      if (!ModelState.IsValid)
      {
        throw new HttpResponseException(HttpStatusCode.BadRequest);
      }

      var dbCustomer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
      if (dbCustomer is null)
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }

      _dbContext.Customers.Remove(dbCustomer);

      _dbContext.SaveChanges();
    }
  }
}
