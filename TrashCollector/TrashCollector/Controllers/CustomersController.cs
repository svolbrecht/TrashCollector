using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            Customer customer;
            if (id == null)
            {
                var userId = User.Identity.GetUserId();
                customer = db.Customer.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
            }
            else
            {
                customer = db.Customer.Find(id);
            }

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,City,State,Zipcode,WeeklyPickUp")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ApplicationUserId = User.Identity.GetUserId();
                customer.Balance = 0;
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            return View("Details");
        }

        public ActionResult Pickups()
        {
            var userId = User.Identity.GetUserId();
            var currentUser = db.Customer.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
            return View(currentUser);
        }

        [HttpPost]
        public ActionResult Pickups([Bind(Include = "Id,Name,Address,City,State,Zipcode,WeeklyPickUp,SpecialPickUp,StartPickUp,EndPickUp")]Customer customer)
        {
            var userId = User.Identity.GetUserId();
            var currentUser = db.Customer.Where(c => c.ApplicationUserId == userId).FirstOrDefault();

            //currentUser.Name = currentUser.Name;
            //currentUser.Address = currentUser.Address;
            //currentUser.City = currentUser.City;
            //currentUser.State = currentUser.State;
            //currentUser.Zipcode = currentUser.Zipcode;
            currentUser.WeeklyPickUp = customer.WeeklyPickUp;
            currentUser.SpecialPickUp = customer.SpecialPickUp;
            currentUser.StartPickUp = customer.StartPickUp;
            currentUser.EndPickUp = customer.EndPickUp;
            db.SaveChanges();
            return RedirectToAction("Details");
            // return View("Details");

        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            Customer customer;
            if (id == null)
            {
                var userId = User.Identity.GetUserId();
                customer = db.Customer.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
            }
            else
            {
                customer = db.Customer.Find(id);
            }

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,City,State,Zipcode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(customer);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            Customer customer;
            if (id == null)
            {
                var userId = User.Identity.GetUserId();
                customer = db.Customer.Where(c => c.ApplicationUserId == userId).FirstOrDefault();
            }
            else
            {
                customer = db.Customer.Find(id);
            }

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
