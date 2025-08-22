using Proje7MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje7MVC.Controllers
{
    public class EmployeeController : Controller
    {
        PROJE7MVCEntities1 db = new PROJE7MVCEntities1();
        public ActionResult EmployeeList()
        {
            var values=db.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateEmployee(Employees employees)
        {
            db.Employees.Add(employees);
            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var value = db.Employees.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employees employees)
        {
            var value = db.Employees.Find(employees.EmployeeId);
            if (value == null)
            {
                // Kayıt bulunamazsa hata veya yönlendirme
                return HttpNotFound("Employee not found.");
            }
            value.Name = employees.Name;
            value.Surname = employees.Surname;
            value.Profession = employees.Profession;
            value.LinkedinUrl = employees.LinkedinUrl;
            value.InstagramUrl = employees.InstagramUrl;
            value.ImageUrl = employees.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("EmployeeList");
        }
        public ActionResult DeleteEmployee(int id)
        {
            var value = db.Employees.FirstOrDefault(x=>x.EmployeeId==id);
            db.Employees.Remove(value);
            db.SaveChanges();
            return RedirectToAction("EmployeeList");

        }
    }
}