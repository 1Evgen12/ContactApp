using ContactAppFull.Server.Model;
using ContactAppFull.Server.ModelDto;

namespace ContactAppFull.Server.Storage
{
    public class InMemoryStorage: IStorage
    {
        private List<Contact> Contacts { get; set; }

        public InMemoryStorage()
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
        //public Contact GetContactById(int id)
        //{
        //    foreach (var item in Contacts)
        //    {
        //        if (item.ID == id)
        //            return item;
        //    }
        //    return null;
        //}
        public Contact Add(Contact contact) {

            foreach (var item in Contacts)
            {
                if (item.ID == contact.ID) 
                    return null;
            }

            Contacts.Add (contact);
            return contact;
        }

        public bool Remove(int id) {


            Contact contact;
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (Contacts[i].ID == id)
                {
                    contact = Contacts[i];
                    Contacts.Remove(contact);
                    return true;
                }
            }
            return false;
        }
        public bool UpdateContact(ContactDto contactDto, int id)
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
                    return true;
                }
            }
            return false;
        }
    }
}
