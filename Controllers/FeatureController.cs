using Proje7MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje7MVC.Controllers
{
    public class FeatureController : Controller
    {
        PROJE7MVCEntities1 db = new PROJE7MVCEntities1();
        public ActionResult Index()
        {
            var values = db.Features.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateFeature(Features features)
        {
            db.Features.Add(features);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.Features.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFeature(Features features)
        {
            var value = db.Features.Find(features.FeatureId);
            if (value == null)
            {
                // Kayıt bulunamazsa hata veya yönlendirme
                return HttpNotFound("Features not found.");
            }
            value.Title = features.Title;
            value.Description = features.Description;
            value.Icon = features.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFeature(int id)
        {
            var value = db.Features.FirstOrDefault(x => x.FeatureId == id);
            db.Features.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}