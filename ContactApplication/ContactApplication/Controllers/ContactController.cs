using ContactApplication.Models;
using ContactApplication.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ContactApplication.Controllers
{
    public class ContactController : Controller
    {
        

        EFRepository _repository = new EFRepository();

        // GET: Contact
        public ActionResult Index()
        {
            return View(_repository.GetContacts());        
        }

        // GET: Contact/Details/5
        [ActionName("Details")]
        public ActionResult Details(int id)
        {
            return View(_repository.GetContactById(id));
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                // TODO: Add insert logic here
                _repository.InsertContact(contact);
                _repository.Save();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = _repository.GetContactById(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int id)
        {
            var contacttoUpdate = _repository.GetContactById(id);

            if (contacttoUpdate == null)
            {
                return HttpNotFound();
            }

            if (TryUpdateModel(contacttoUpdate, String.Empty, new string[] { "Firstname", "Lastname", "Email", "Phone" }))
            {
                try
                {
                    _repository.UpdateContact(contacttoUpdate);
                    _repository.Save();
                    TempData["success"] = "Ändringarna sparade.";
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    TempData["error"] = "Misslyckades att spara ändringarna.";
                }
            }

            return View(contacttoUpdate);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Contact contact = _repository.GetContactById(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var contactToDelete = new Contact { ContactID = id };
                _repository.DeleteContact(contactToDelete);
                _repository.Save();
                TempData["success"] = "Kontakten togs bort.";
            }
            catch (DataException)
            {
                TempData["error"] = "Misslyckades att ta bort kontakten.";
                return RedirectToAction("Delete", new { id = id });
            }

            return RedirectToAction("Index");
        }
    }
}
