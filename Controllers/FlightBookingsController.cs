using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using flightbooking_project.Models;

namespace flightbooking_project.Controllers
{
    public class FlightBookingsController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: FlightBookings
        public ActionResult Index()
        {
            var flightBookings = db.FlightBookings.Include(f => f.TicketReservation_tbls);
            return View(flightBookings.ToList());
        }

        // GET: FlightBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightBooking flightBooking = db.FlightBookings.Find(id);
            if (flightBooking == null)
            {
                return HttpNotFound();
            }
            return View(flightBooking);
        }

        // GET: FlightBookings/Create
        public ActionResult Create()
        {
            ViewBag.ResId = new SelectList(db.TicketReservations, "ResId", "ResFrom");
            return View();
        }

        // POST: FlightBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bId,bCusName,bCusAddress,bCusEmail,bCusSeats,bCusPhoneNum,ResId")] FlightBooking flightBooking)
        {
            if (ModelState.IsValid)
            {
                db.FlightBookings.Add(flightBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResId = new SelectList(db.TicketReservations, "ResId", "ResFrom", flightBooking.ResId);
            return View(flightBooking);
        }

        // GET: FlightBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightBooking flightBooking = db.FlightBookings.Find(id);
            if (flightBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResId = new SelectList(db.TicketReservations, "ResId", "ResFrom", flightBooking.ResId);
            return View(flightBooking);
        }

        // POST: FlightBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bId,bCusName,bCusAddress,bCusEmail,bCusSeats,bCusPhoneNum,ResId")] FlightBooking flightBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flightBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResId = new SelectList(db.TicketReservations, "ResId", "ResFrom", flightBooking.ResId);
            return View(flightBooking);
        }

        // GET: FlightBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlightBooking flightBooking = db.FlightBookings.Find(id);
            if (flightBooking == null)
            {
                return HttpNotFound();
            }
            return View(flightBooking);
        }

        // POST: FlightBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlightBooking flightBooking = db.FlightBookings.Find(id);
            db.FlightBookings.Remove(flightBooking);
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
