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
    public class ParkingMembersController : Controller
    {
        private SmartParkEntities db = new SmartParkEntities();

        // GET: ParkingMembers
        public ActionResult Index()
        {
            return View(db.ParkingMembers.ToList());
        }

        // GET: ParkingMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingMember parkingMember = db.ParkingMembers.Find(id);
            if (parkingMember == null)
            {
                return HttpNotFound();
            }
            return View(parkingMember);
        }

        // GET: ParkingMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkingMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingMemberID,ParkingMemberName,ParkingMemberCarMake,ParkingMemberCarModel,ParkingMemberCarYear,ParkingMemberPlate,ParkingMemberElite")] ParkingMember parkingMember)
        {
            if (ModelState.IsValid)
            {
                db.ParkingMembers.Add(parkingMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkingMember);
        }

        // GET: ParkingMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingMember parkingMember = db.ParkingMembers.Find(id);
            if (parkingMember == null)
            {
                return HttpNotFound();
            }
            return View(parkingMember);
        }

        // POST: ParkingMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingMemberID,ParkingMemberName,ParkingMemberCarMake,ParkingMemberCarModel,ParkingMemberCarYear,ParkingMemberPlate,ParkingMemberElite")] ParkingMember parkingMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkingMember);
        }

        // GET: ParkingMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingMember parkingMember = db.ParkingMembers.Find(id);
            if (parkingMember == null)
            {
                return HttpNotFound();
            }
            return View(parkingMember);
        }

        // POST: ParkingMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingMember parkingMember = db.ParkingMembers.Find(id);
            db.ParkingMembers.Remove(parkingMember);
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
