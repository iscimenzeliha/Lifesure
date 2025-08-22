using Proje7MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje7MVC.Controllers
{
    public class TestimonialController : Controller
    {
        PROJE7MVCEntities1 db = new PROJE7MVCEntities1();
        public ActionResult TestimonialList()
        {
            var values = db.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonials testimonials)
        {
            db.Testimonials.Add(testimonials);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.Testimonials.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonials testimonials)
        {
            var value = db.Testimonials.Find(testimonials.TestimonialId);
            if (value == null)
            {
                // Kayıt bulunamazsa hata veya yönlendirme
                return HttpNotFound("Testimonial not found.");
            }
            value.NameSurname = testimonials.NameSurname;
            value.Profession = testimonials.Profession;
            value.Description = testimonials.Description;
            value.ImageUrl = testimonials.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.Testimonials.FirstOrDefault(x => x.TestimonialId == id);
            db.Testimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("TestimonialList");

        }
    }
}