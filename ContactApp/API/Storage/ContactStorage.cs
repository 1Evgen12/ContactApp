using ContactApp.API.ModelDto;
using ContactApp.Model;

namespace ContactApp.API.Storage
{
    public class ContactStorage
    {
        private List<Contact> Contacts { get; set; }

        public ContactStorage()
        {
            Contacts = new List<Contact>();

            for (int i = 1; i <= 5; i++)
            {
                Contacts.Add(new Contact()
                {
                    ID = i,
                    Name = $"Полное имя {i}",
                    Email = $"{Guid.NewGuid().ToString().Substring(0, 5)}{i}@mail.ru",
                    Address = $"Адрес {i}",
                    PhoneNumber = $"Телефон {i}"
                });
            }


        }

        public List<Contact> GetContacts()
        {
            return this.Contacts;
        }
        public void Add(Contact contact) {
            Contacts.Add (contact);
        }

        public void Remove(int id) {


            Contact contact;
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (Contacts[i].ID == id)
                {
                    contact = Contacts[i];
                    Contacts.Remove(contact);
                    return;
                }
            }
        }
        public void UpdateContact(ContactDto contactDto, int id)
        {
            Contact contact;
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (Contacts[i].ID == id)
                {
                    contact = Contacts[i];
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
    }
}
