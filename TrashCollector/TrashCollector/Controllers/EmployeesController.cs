using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees

        public ActionResult Index()
        {
            DateTime dateTime = DateTime.Now;
            var dayOfWeek = dateTime.DayOfWeek.ToString();
            var userId = User.Identity.GetUserId();
            var currentEmployee = db.Employee.Where(e => e.ApplicationUserId == userId).FirstOrDefault();
            var employeeZip = currentEmployee.Zipcode; 
            var customersInZip = db.Customer.Where(c => c.Zipcode == employeeZip);
            var customersInZipForDay = customersInZip.Where(d => d.WeeklyPickUp == dayOfWeek);
            //var specialPickups = db.Customer.Where(c => c.SpecialPickUp.ToString() == dayOfWeek).ToList();
            var shortDate = dateTime.ToShortDateString();
            var specialPickups = db.Customer.Where(c => c.SpecialPickUp == shortDate);
            var customersForDay = customersInZipForDay.Union(specialPickups);
            customersForDay.ToList();
            return View(customersForDay);
            //db.Employee.ToList()
        }

        public ActionResult PickupsForChosenDay(string chosenDay)
        {
           /* chosenDay =;*/ //input from drop down menu of days of week;
            var userId = User.Identity.GetUserId();
            var currentEmployee = db.Employee.Where(e => e.ApplicationUserId == userId).FirstOrDefault();
            var employeeZip = currentEmployee.Zipcode;
            var customersInZip = db.Customer.Where(c => c.Zipcode == employeeZip);
            var customersInZipForDay = customersInZip.Where(d => d.WeeklyPickUp == chosenDay).ToList();
            return View(customersInZipForDay);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
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
        public ActionResult Create([Bind(Include = "Id,Name,Zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationUserId = User.Identity.GetUserId();
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            Customer customer = db.Customer.Find(id);
            if (id == null)
            {
              
            }


            //if (customer == null)
            //{
            //    return HttpNotFound();
            //}
            return View(customer);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,City,State,Zipcode,WeeklyPickUp,SpecialPickUp,StartPickUp,EndPickUp")]Customer customer)
        {
            var currentCustomer = db.Customer.Find(customer.Id);
            //customer.Balance ;

            //db.SaveChanges();
            if (ModelState.IsValid)
            {
                currentCustomer.Balance = customer.Balance;
                //db.Entry(currentCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
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
