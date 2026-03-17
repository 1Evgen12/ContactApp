using ContactAppFull.Server.ModelDto;
using ContactAppFull.Server.Model;

namespace ContactAppFull.Server.Storage
{
    public interface IStorage
    {
        List<Contact> GetContacts();
        Contact Add(Contact contact);
        bool UpdateContact(ContactDto contactDto, int id);
        bool Remove(int id);
       
    }
}
