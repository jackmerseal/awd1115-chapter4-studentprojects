using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext Context { get; set; }

        public HomeController(ContactContext ctx)
        {
            Context = ctx;
        }

        public IActionResult Index()
        {
            var contacts = Context.Contacts.OrderBy(c => c.Firstname).ToList();
            return View(contacts);
        }
    }
}
