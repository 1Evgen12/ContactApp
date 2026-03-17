using ContactAppFull.Server.DataContext;
using ContactAppFull.Server.Model;
using ContactAppFull.Server.ModelDto;

namespace ContactAppFull.Server.Storage
{
    public class SqliteEfStorage:IStorage
    {
        protected readonly SqliteDbContext context;

        public SqliteEfStorage(SqliteDbContext context)
        {
            this.context = context;
        }
        public Contact Add(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return contact;
        }

        //public Contact GetContactById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Contact> GetContacts()
        {
            return context.Contacts.ToList();
        }

        public bool Remove(int id)
        {
            var contact = context.Contacts.Find(id);
            if(contact == null)
            {
                return false;
            }
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return true;
        }

        public bool UpdateContact(ContactDto contactDto, int id)
        {
            var contact = context.Contacts.Find(id);
            if (contact == null) { 
                return false;
            }
            contact.Name = contactDto.Name;
            contact.Email = contactDto.Email;
            contact.PhoneNumber = contactDto.PhoneNumber;
            contact.Address = contactDto.Address;
            context.SaveChanges();
            return true;
        }
    }
}
