using Proje7MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje7MVC.Controllers
{
    public class SliderController : Controller
    {
        PROJE7MVCEntities1 db = new PROJE7MVCEntities1();
        public ActionResult SliderList()
        {
            var values = db.Sliders.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSlider()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateSlider(Sliders sliders)
        {
            db.Sliders.Add(sliders);
            db.SaveChanges();
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var value = db.Sliders.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSlider(Sliders sliders)
        {
            var value = db.Sliders.Find(sliders.SliderId);
            if (value == null)
            {
                // Kayıt bulunamazsa hata veya yönlendirme
                return HttpNotFound("Slider not found.");
            }
            value.Title = sliders.Title;
            value.SubTitle = sliders.SubTitle;
            value.Description = sliders.Description;
            value.ImageUrl = sliders.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("SliderList");
        }
        public ActionResult DeleteSlider(int id)
        {
            var value = db.Sliders.FirstOrDefault(x => x.SliderId == id);
            db.Sliders.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SliderList");

        }
    }
}