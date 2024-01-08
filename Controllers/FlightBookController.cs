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
    public class FlightBookController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: FlightBook
        public ActionResult Index()
        {
            ViewBag.dcity = db.TicketReservations.Select(I => I.ResFrom).Distinct().ToList();
            ViewBag.dcity = db.TicketReservations.Select(I => I.ResTo).Distinct().ToList();
            return View();

        }
        [HttpPost]

        public ActionResult Search(string cityto, string cityfrom, string date1)
        {
            var c = db.TicketReservations.Where(I => I.ResTo.Equals(cityto) && I.ResFrom.Equals(cityfrom) && I.ResDepDate.Equals(date1));
            ViewBag.ss = c;
            return View();

        }

        // GET: FlightBook/Create
        public ActionResult Create()
        {
            ViewBag.PlaneId = new SelectList(db.PlaneInfo, "PlaneId", "AirplaneName");
            return View();
        }

        // POST: FlightBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResId,ResFrom,ResTo,ResDepDate,PlaneId,planeSeat,ResTicketPrice,ResPlaneType")] TicketReservation ticketReservation)
        {
            if (ModelState.IsValid)
            {
                db.TicketReservations.Add(ticketReservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaneId = new SelectList(db.PlaneInfo, "PlaneId", "AirplaneName", ticketReservation.PlaneId);
            return View(ticketReservation);
        }

        // GET: FlightBook/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReservation ticketReservation = db.TicketReservations.Find(id);
            if (ticketReservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaneId = new SelectList(db.PlaneInfo, "PlaneId", "AirplaneName", ticketReservation.PlaneId);
            return View(ticketReservation);
        }

        // POST: FlightBook/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResId,ResFrom,ResTo,ResDepDate,PlaneId,planeSeat,ResTicketPrice,ResPlaneType")] TicketReservation ticketReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketReservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaneId = new SelectList(db.PlaneInfo, "PlaneId", "AirplaneName", ticketReservation.PlaneId);
            return View(ticketReservation);
        }

        // GET: FlightBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketReservation ticketReservation = db.TicketReservations.Find(id);
            if (ticketReservation == null)
            {
                return HttpNotFound();
            }
            return View(ticketReservation);
        }

        // POST: FlightBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketReservation ticketReservation = db.TicketReservations.Find(id);
            db.TicketReservations.Remove(ticketReservation);
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
