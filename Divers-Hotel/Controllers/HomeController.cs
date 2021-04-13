using Divers_Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Divers_Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly Entities db = new Entities();

        public ActionResult GetReservationTotal()
        {
            ViewBag.RoomTypes = GeRoomTypes();
            ViewBag.MealPlans = GeMealPlans();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetReservationTotal(tbReservation tbreservation)
        {
            if (ModelState.IsValid)
            {
                int? num = tbreservation.reservationAdultNumber + tbreservation.reservationChildNumber;
                double? numdays = (Convert.ToDateTime(tbreservation.reservationCheckOutDate) - Convert.ToDateTime(tbreservation.reservationCheckInDate)).TotalDays;

                var mealPrice = db.tbMealPlans.Find(tbreservation.reservationMealPlanId);
                var roomType = db.tbRoomTypes.Find(tbreservation.reservationRoomTypeId);

                DateTime from = new DateTime(2021, 1, 1);
                DateTime to = new DateTime(2021, 5, 30);
                string total;

                if (Convert.ToDateTime(tbreservation.reservationCheckInDate).Ticks > from.Ticks && Convert.ToDateTime(tbreservation.reservationCheckInDate).Ticks < to.Ticks)
                {
                    total = Convert.ToString((Convert.ToInt32(roomType.roomPrice) * numdays) + (Convert.ToInt32(mealPrice.mealPlanPriceInLowSeason) * num));
                }
                else
                {
                    total = Convert.ToString((Convert.ToInt32(roomType.roomPrice) * numdays) + (Convert.ToInt32(mealPrice.mealPlanPriceinHighSeason) * num));
                }

                tbreservation.reservationTotalPrice = total;

                db.tbReservations.Add(tbreservation);
                db.SaveChanges();
                return RedirectToAction("TotalResult", new { total = tbreservation.reservationTotalPrice });
            }

            return View(tbreservation);
        }

        public ActionResult TotalResult(string total)
        {
            TempData["alertMessage"] = "Your Total Price = $" + total;
            return View();
        }


        public List<SelectListItem> GeRoomTypes()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var gender = db.tbRoomTypes.ToList();
            foreach (var item in gender)
            {
                list.Add(new SelectListItem { Value = item.roomTypeId.ToString(), Text = item.roomTypeName });
            }
            return list;
        }

        public List<SelectListItem> GeMealPlans()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var gender = db.tbMealPlans.ToList();
            foreach (var item in gender)
            {
                list.Add(new SelectListItem { Value = item.mealPlanId.ToString(), Text = item.mealPlanName });
            }
            return list;
        }

    }
}