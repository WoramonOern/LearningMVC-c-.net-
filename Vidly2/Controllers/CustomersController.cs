using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    //base.Dispose(disposing);
        //    _context.Dispose();
        //}

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerMembershipTypeViewModel
            {
                membershiptypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(CustomerMembershipTypeViewModel postCustomer)//(CustomerMembershipTypeViewModel viewModel) // customer class is easy to pass all of data
        {
            var customer = new Customer
            {
                Name = postCustomer.customers.Name,
                IsSubscribedToNewsletter = postCustomer.customers.IsSubscribedToNewsletter,
                MembershipTypeId = postCustomer.customers.MembershipTypeId,
                BirthDate = postCustomer.customers.BirthDate
                //BirthDate = new DateTime(2010, 03, 18)
            };
            // is a memory - not add to db yet
            _context.Customers.Add(customer);
            //// save/modify all of data to the db 
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers"); 
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers); 
            //return View();
        }

        // GET: Customers/Details/{id}
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerMembershipTypeViewModel
            {
                customers = customer,
                membershiptypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>()
        //    {
        //        new Customer() { Id = 1, Name = "John Smith" },
        //        new Customer() { Id = 2, Name = "Mary Williams" }
        //    };
        //}
    }
}