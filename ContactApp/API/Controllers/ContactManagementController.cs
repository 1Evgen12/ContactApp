using ContactApp.API.ModelDto;
using ContactApp.API.Storage;
using ContactApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.API.Controllers
{
    public class ContactManagementController:BaseController
    {
        private readonly ContactStorage storage;

        public ContactManagementController(ContactStorage storage)
        {
            this.storage = storage;
        }

        [HttpPost("contacts")]
        public void Create([FromBody] Contact contact)
        {
            storage.Add(contact);
        }

        [HttpGet("contacts")]
        public List<Contact> Contact()
        {
            return storage.GetContacts();
        }

        [HttpPut("contacts/{id}")]
        public void UpdateContact([FromBody]ContactDto contactDto, int id)
        {
            storage.UpdateContact(contactDto, id);
        }

        [HttpDelete("contacts/{id}")]
        public void DeleteContact(int id)
        {
            storage.Remove(id);
        }
    }
}
