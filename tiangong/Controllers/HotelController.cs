using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tiangong.Models;
using tiangong.Repository;

namespace tiangong.Controllers
{
    public class HotelController : Controller
    {
        // GET: HotelController
        TGContext tgContext;
        public HotelController(TGContext context)
        {
            tgContext = context;
        }
        public ActionResult Index()
        {
            var newHotel = new Hotel()
            {
                id = 1,
                name = "龙门客栈",
                address = "太湖香山",
                star = 5
            };
            tgContext.Add(newHotel);
            tgContext.SaveChanges();
            var hotel = tgContext.Hotels.FirstOrDefault(m => m.id == newHotel.id);
            return new JsonResult(hotel);
        }

        // GET: HotelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HotelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
