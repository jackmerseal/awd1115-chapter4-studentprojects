using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

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
            ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Contact";
            ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
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
                ViewBag.Categories = Context.Categories.OrderBy(c => c.Name).ToList();
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
			//var contact = Context.Contacts.Find(id);
            var contact2 = Context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);
            //var contact = Context.Contacts.Include(c => c.Category).FirstOrDefault(c => c.ContactId == id);
			return View(contact2);
		}

        public IActionResult Index()
        {
            return View();
        }
    }
}
