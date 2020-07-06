using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET  api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(r => r.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(r => r.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST api/customers/
        [HttpPost]
        public IHttpActionResult Create(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }

        //PUT api/customers/1
        [HttpPut]
        public IHttpActionResult Update(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _context.Customers.SingleOrDefault(r => r.Id == id);
            if (customerInDb == null)
                return NotFound();
            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE api/customers/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(r => r.Id == id);
            if (customerInDb == null)
                return NotFound();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
