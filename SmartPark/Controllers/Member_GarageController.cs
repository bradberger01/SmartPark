using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartPark.Models;

namespace SmartPark.Controllers
{
    public class Member_GarageController : Controller
    {
        private SmartParkEntities db = new SmartParkEntities();

        // GET: Member_Garage
        public ActionResult Index()
        {
            var member_Garage = db.Member_Garage.Include(m => m.Garage).Include(m => m.ParkingMember);
            return View(member_Garage.ToList());
        }

        // GET: Member_Garage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Garage member_Garage = db.Member_Garage.Find(id);
            if (member_Garage == null)
            {
                return HttpNotFound();
            }
            return View(member_Garage);
        }

        // GET: Member_Garage/Create
        public ActionResult Create()
        {
            ViewBag.GarageID = new SelectList(db.Garages, "GarageID", "GarageName");
            ViewBag.ParkingMemberID = new SelectList(db.ParkingMembers, "ParkingMemberID", "ParkingMemberName");
            return View();
        }

        // POST: Member_Garage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingMemberID,GarageID,ReservedParkingSpace,ID")] Member_Garage member_Garage)
        {
            if (ModelState.IsValid)
            {
                db.Member_Garage.Add(member_Garage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GarageID = new SelectList(db.Garages, "GarageID", "GarageName", member_Garage.GarageID);
            ViewBag.ParkingMemberID = new SelectList(db.ParkingMembers, "ParkingMemberID", "ParkingMemberName", member_Garage.ParkingMemberID);
            return View(member_Garage);
        }

        // GET: Member_Garage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Garage member_Garage = db.Member_Garage.Find(id);
            if (member_Garage == null)
            {
                return HttpNotFound();
            }
            ViewBag.GarageID = new SelectList(db.Garages, "GarageID", "GarageName", member_Garage.GarageID);
            ViewBag.ParkingMemberID = new SelectList(db.ParkingMembers, "ParkingMemberID", "ParkingMemberName", member_Garage.ParkingMemberID);
            return View(member_Garage);
        }

        // POST: Member_Garage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingMemberID,GarageID,ReservedParkingSpace,ID")] Member_Garage member_Garage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member_Garage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GarageID = new SelectList(db.Garages, "GarageID", "GarageName", member_Garage.GarageID);
            ViewBag.ParkingMemberID = new SelectList(db.ParkingMembers, "ParkingMemberID", "ParkingMemberName", member_Garage.ParkingMemberID);
            return View(member_Garage);
        }

        // GET: Member_Garage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Garage member_Garage = db.Member_Garage.Find(id);
            if (member_Garage == null)
            {
                return HttpNotFound();
            }
            return View(member_Garage);
        }

        // POST: Member_Garage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member_Garage member_Garage = db.Member_Garage.Find(id);
            db.Member_Garage.Remove(member_Garage);
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
