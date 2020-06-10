using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ViewResult Index()
        {
            var customers = GetAllCustomer();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetAllCustomer().SingleOrDefault(r => r.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        private List<Customer> GetAllCustomer()
        {
            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Jahangir"},
                new Customer {Id = 2, Name = "Rubel"}
            };
            return customers;
        }
    }
}