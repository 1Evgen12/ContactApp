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
            storage.Contacts.Add(contact);
        }

        [HttpGet("contacts")]
        public List<Contact> Contact()
        {
            return storage.Contacts;
        }

        [HttpPut("contacts/{id}")]
        public void UpdateContact([FromBody]ContactDto contactDto, int id)
        {
            Contact contact;
            for (int i = 0; i < storage.Contacts.Count; i++)
            {
                if (storage.Contacts[i].ID == id)
                {
                    contact = storage.Contacts[i];
                    if (!String.IsNullOrEmpty(contactDto.Email)) 
                    { 
                        contact.Email = contactDto.Email; 
                    }
                    if (!String.IsNullOrEmpty(contactDto.Name))
                    {
                        contact.Name = contactDto.Name;
                    }
                    if (!String.IsNullOrEmpty(contactDto.PhoneNumber))
                    {
                        contact.PhoneNumber = contactDto.PhoneNumber;
                    }
                    if (!String.IsNullOrEmpty(contactDto.Address))
                    {
                        contact.Address = contactDto.Address;
                    }
                    
                }
            }
        }

        [HttpDelete("contacts/{id}")]
        public void DeleteContact(int id)
        {
            Contact contact;
            for (int i = 0; i < storage.Contacts.Count; i++)
            {
                if (storage.Contacts[i].ID == id)
                {
                    contact = storage.Contacts[i];
                    storage.Contacts.Remove(contact);
                    return;
                }
            }
        }
    }
}
