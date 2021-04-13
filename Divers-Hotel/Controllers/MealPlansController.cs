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
    public class MealPlansController : Controller
    {
        private Entities db = new Entities();

        // GET: MealPlans
        public ActionResult Index()
        {
            return View(db.tbMealPlans.ToList());
        }

        // GET: MealPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMealPlan tbMealPlan = db.tbMealPlans.Find(id);
            if (tbMealPlan == null)
            {
                return HttpNotFound();
            }
            return View(tbMealPlan);
        }

        // GET: MealPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MealPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mealPlanId,mealPlanName,mealPlanPriceInLowSeason,mealPlanPriceinHighSeason")] tbMealPlan tbMealPlan)
        {
            if (ModelState.IsValid)
            {
                db.tbMealPlans.Add(tbMealPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbMealPlan);
        }

        // GET: MealPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMealPlan tbMealPlan = db.tbMealPlans.Find(id);
            if (tbMealPlan == null)
            {
                return HttpNotFound();
            }
            return View(tbMealPlan);
        }

        // POST: MealPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mealPlanId,mealPlanName,mealPlanPriceInLowSeason,mealPlanPriceinHighSeason")] tbMealPlan tbMealPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbMealPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbMealPlan);
        }

        // GET: MealPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMealPlan tbMealPlan = db.tbMealPlans.Find(id);
            if (tbMealPlan == null)
            {
                return HttpNotFound();
            }
            return View(tbMealPlan);
        }

        // POST: MealPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbMealPlan tbMealPlan = db.tbMealPlans.Find(id);
            db.tbMealPlans.Remove(tbMealPlan);
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
