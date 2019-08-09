using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsApi.Models;
using ContactsApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<List<Contacts>> Get() =>
            _contactService.Get();

        [HttpGet("{id:length(24)}", Name = "GetContact")]
        public ActionResult<Contacts> Get(string id)
        {
            var contact = _contactService.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpPost]
        public ActionResult<Contacts> Create(Contacts contact)
        {
            _contactService.Create(contact);

            return CreatedAtRoute("GetContact", new { id = contact.Id.ToString() }, contact);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Contacts contactIn)
        {
            var contact = _contactService.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            _contactService.Update(id, contactIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var contact = _contactService.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            _contactService.Remove(contact.Id);

            return NoContent();
        }
    }
}
