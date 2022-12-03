using Microsoft.AspNetCore.Mvc;
using PracticeWebAPI.Data;
using PracticeWebAPI.Models;

namespace PracticeWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ContactAPIDbContext _contactAPIDbContext;

        public ContactController(ContactAPIDbContext contactAPIDbContext)
        {
            _contactAPIDbContext = contactAPIDbContext;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contact = _contactAPIDbContext.contacts.ToList();

            return View(contact);
        }

        [HttpPost]
        public IActionResult Add(AddContact addContact)
        {

            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FullName = addContact.FullName,
                Email = addContact.Email,
                PhoneNumber = addContact.PhoneNumber,
                Address = addContact.Address,


            };

            _contactAPIDbContext.contacts.Add(contact);

            _contactAPIDbContext.SaveChanges();

            return RedirectToAction("GetAllContacts");
        }
    }  
}
