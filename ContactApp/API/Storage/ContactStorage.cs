using ContactApp.Model;

namespace ContactApp.API.Storage
{
    public class ContactStorage
    {
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
        public List<Contact> Contacts { get; set; }
    }
}
