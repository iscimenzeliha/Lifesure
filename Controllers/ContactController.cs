using Proje7MVC.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje7MVC.Controllers
{
    public class ContactController : Controller
    {
        PROJE7MVCEntities1 db = new PROJE7MVCEntities1();
        public ActionResult ContactList()
        {
            var values=db.Contacts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();

        }
        [HttpPost]
        public ActionResult CreateContact(Contacts contacts)
        {
            db.Contacts.Add(contacts);
            db.SaveChanges();
            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.Contacts.Find(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateContact(Contacts contacts)
        {
            var value = db.Contacts.Find(contacts.ContactId);
            if (value == null)
            {
                // Kayıt bulunamazsa hata veya yönlendirme
                return HttpNotFound("Contact not found.");
            }
            value.Address = contacts.Address;
            value.Mail = contacts.Mail;
            value.Telephone = contacts.Telephone;
            db.SaveChanges();
            return RedirectToAction("ContactList");
        }
        public ActionResult DeleteContact(int id)
        {
            var value = db.Contacts.FirstOrDefault(x => x.ContactId == id);
            db.Contacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ContactList");

        }
    }
}