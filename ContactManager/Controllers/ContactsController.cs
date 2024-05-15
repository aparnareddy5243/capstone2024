using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;
using ContactManager.Services;

namespace ContactManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_contactService.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null) return NotFound();
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            _contactService.Add(contact);
            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return NoContent();
        }
    }
}
