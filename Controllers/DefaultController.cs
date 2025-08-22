using Newtonsoft.Json.Linq;
using Proje7MVC.Models.DataModels;
using Proje7MVC.Models.ViewModels;
using Proje7MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Proje7MVC.Controllers
{
    public class DefaultController : Controller
    {
       PROJE7MVCEntities1 db=new PROJE7MVCEntities1();

        public async Task<ActionResult> Index()
        {
            var service = new LinkedinService();
            int followers = await service.GetFollowerCountAsync("lifesure-group-ltd"); // LinkedIn URL son kısmı
            ViewBag.LinkedInFollowers = followers;

            return View();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult SliderPartial()
        {
            var values = db.Sliders.ToList();
            return PartialView(values);
        }
        public PartialViewResult FeaturePartial()
        {
            var values = db.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult AboutPartial()
        {
            var value = db.Abouts.FirstOrDefault();
            return PartialView(value);
        }

        public PartialViewResult ServicePartial()
        {
            var values = db.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult FaqPartial()
        {
            var values = db.Faqs.ToList();
            return PartialView(values);
        }

        public PartialViewResult EmployeePartial()
        {
            var values = db.Employees.ToList();
            return PartialView(values);
        }

        public PartialViewResult TestimonialPartial()
        {
            var values = db.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult FooterPartial()
        {
            var value = db.Contacts.FirstOrDefault();
            return PartialView(value);
        }
        public PartialViewResult TopbarPartial()
        {
            return PartialView();
        }


    }
}