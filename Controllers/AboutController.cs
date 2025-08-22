using Proje7MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje7MVC.Controllers
{
    public class AboutController : Controller
    {
      PROJE7MVCEntities1 db= new PROJE7MVCEntities1();
        public ActionResult AboutList()
        {
            var values=db.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.Abouts.Find(id);
            if (value == null)
            {
                return HttpNotFound("About not found.");
            }
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(Abouts abouts)
        {
            if (!ModelState.IsValid)
            {
                return View(abouts); // ModelState hatalarını göster
            }

            var value = db.Abouts.Find(abouts.AboutId);
            if (value == null)
            {
                return HttpNotFound("About not found.");
            }

            try
            {
                value.Title = abouts.Title;
                value.Description = abouts.Description;
                value.Point1 = abouts.Point1;
                value.Point2 = abouts.Point2;
                value.Point3 = abouts.Point3;
                value.InsurancePolicies = abouts.InsurancePolicies;
                value.SkilledAgents = abouts.SkilledAgents;
                value.AwardsWON = abouts.AwardsWON;
                value.TeamMembers = abouts.TeamMembers;

                db.SaveChanges();
                return RedirectToAction("AboutList");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                // Validation hatalarını ModelState'e ekle
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        ModelState.AddModelError(ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return View(abouts);
            }
        }
    }
}