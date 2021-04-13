using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Divers_Hotel.Models;

namespace Divers_Hotel.Controllers
{
    public class RoomTypesController : Controller
    {
        private Entities db = new Entities();

        // GET: RoomTypes
        public ActionResult Index()
        {
            return View(db.tbRoomTypes.ToList());
        }

        // GET: RoomTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRoomType tbRoomType = db.tbRoomTypes.Find(id);
            if (tbRoomType == null)
            {
                return HttpNotFound();
            }
            return View(tbRoomType);
        }

        // GET: RoomTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "roomTypeId,roomTypeName,fromDate,toDate,roomPrice")] tbRoomType tbRoomType)
        {
            if (ModelState.IsValid)
            {
                db.tbRoomTypes.Add(tbRoomType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbRoomType);
        }

        // GET: RoomTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRoomType tbRoomType = db.tbRoomTypes.Find(id);
            if (tbRoomType == null)
            {
                return HttpNotFound();
            }
            return View(tbRoomType);
        }

        // POST: RoomTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "roomTypeId,roomTypeName,fromDate,toDate,roomPrice")] tbRoomType tbRoomType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbRoomType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbRoomType);
        }

        // GET: RoomTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRoomType tbRoomType = db.tbRoomTypes.Find(id);
            if (tbRoomType == null)
            {
                return HttpNotFound();
            }
            return View(tbRoomType);
        }

        // POST: RoomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbRoomType tbRoomType = db.tbRoomTypes.Find(id);
            db.tbRoomTypes.Remove(tbRoomType);
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
