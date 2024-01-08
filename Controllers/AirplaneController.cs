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
    public class AirplaneController : Controller
    {
        private ContextCS db = new ContextCS();

        // GET: Airplane
        public ActionResult Index()
        {
            return View(db.PlaneInfo.ToList());
        }

        // GET: Airplane/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirplaneInfo airplaneInfo = db.PlaneInfo.Find(id);
            if (airplaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(airplaneInfo);
        }

        // GET: Airplane/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airplane/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaneId,AirplaneName,SeatingCapacity,Price")] AirplaneInfo airplaneInfo)
        {
            if (ModelState.IsValid)
            {
                db.PlaneInfo.Add(airplaneInfo);
                db.SaveChanges();
                ViewBag.m = "رکورد اضافه شد";
                return View();
            }

            return View(airplaneInfo);
        }

        // GET: Airplane/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirplaneInfo airplaneInfo = db.PlaneInfo.Find(id);
            if (airplaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(airplaneInfo);
        }

        // POST: Airplane/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaneId,AirplaneName,SeatingCapacity,Price")] AirplaneInfo airplaneInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airplaneInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airplaneInfo);
        }

        // GET: Airplane/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirplaneInfo airplaneInfo = db.PlaneInfo.Find(id);
            if (airplaneInfo == null)
            {
                return HttpNotFound();
            }
            return View(airplaneInfo);
        }

        // POST: Airplane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AirplaneInfo airplaneInfo = db.PlaneInfo.Find(id);
            db.PlaneInfo.Remove(airplaneInfo);
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
