using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHotel.Data;
using WebHotel.Models;

namespace WebHotel.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // Get: Customers/MyDetails
        public async Task<IActionResult> MyDetails()
        {
            // retrieve the logged-in user's email
            string _email = User.FindFirst(ClaimTypes.Name).Value;
            var newCustomer = await _context.Customer.FindAsync(_email);

            if (newCustomer == null)
            {
                newCustomer = new Customer { Email = _email };
                return View("~/Views/Customers/MyDetailsCreate.cshtml", newCustomer);
            }
            else
            {
                return View("~/Views/Customer/MyDetailsUpdate.cshtml", newCustomer);
            }
        }


        // POST: MovieGoers/MyDetailsCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MyDetailsCreate([Bind("Email,Surname,GivenName,Postcode")] Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newCustomer);
                await _context.SaveChangesAsync();

                return View("~/Views/Customers/MyDetailsSuccess.cshtml", newCustomer);
            }
            return View(newCustomer);
        }


        // POST: MovieGoers/MyDetailsCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MyDetailsUpdate([Bind("Email,Surname,GivenName,Postcode")] Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(newCustomer);
                await _context.SaveChangesAsync();

                return View("~/Views/Customers/MyDetailsSuccess.cshtml", newCustomer);
            }
            return View(newCustomer);
        }

        private bool MovieGoerExists(string id)
        {
            return _context.Customer.Any(e => e.Email == id);
        }
    }
}


    

