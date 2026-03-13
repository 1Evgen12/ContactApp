using ContactApp.API.Model;
using ContactApp.API.ModelDto;
using ContactApp.API.Storage;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.API.Controllers
{
    public class ContactManagementController:BaseController
    {
        private readonly IStorage storage;

        public ContactManagementController(IStorage storage)
        {
            this.storage = storage;
        }

        [HttpPost("contacts")]
        public IActionResult Create([FromBody] Contact contact)
        {
            bool res = storage.Add(contact);
            if (res) return Created();
            return Conflict("Контакт с таким уже ID существует");
        }

        [HttpGet("contacts")]
        public ActionResult<List<Contact>> GetContacts()
        {
            return Ok(storage.GetContacts());
        }
        [HttpGet("contacts/{id}")]
        public ActionResult<Contact> GetContactById(int id)
        {
            if (id <= 0) 
                return BadRequest("Некорректный id");

            Contact contact = storage.GetContactById(id);
            if (contact == null) 
                return NotFound("Контакт не найден");
            else
            {
                return Ok(contact);
            }
        }

        [HttpPut("contacts/{id}")]
        public IActionResult UpdateContact([FromBody]ContactDto contactDto, int id)
        {
            bool res = storage.UpdateContact(contactDto, id);
            if(res) return Ok();
            return Conflict("Контакт с таким ID не существует");
        }

        [HttpDelete("contacts/{id}")]
        public IActionResult DeleteContact(int id)
        {
            bool res = storage.Remove(id);
            if(res) return Ok();
            return BadRequest("Ошибка id");
        }
    }
}
