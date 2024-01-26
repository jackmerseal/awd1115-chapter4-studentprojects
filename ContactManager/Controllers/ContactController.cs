using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext Context { get; set; }

        public ContactController(ContactContext ctx)
        {
            Context = ctx;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = Context.Contacts.Find(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            Context.Contacts.Remove(contact);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add New Contact";
            return View("Edit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Contact";
            var contact = Context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                {
                    Context.Contacts.Add(contact);
                }
                else
                {
                    Context.Contacts.Update(contact);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add New Contact" : "Edit Contact";
                return View(contact);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
