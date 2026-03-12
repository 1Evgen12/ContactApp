using ContactApp.API.ModelDto;
using ContactApp.Model;

namespace ContactApp.API.Storage
{
    public interface IStorage
    {
        List<Contact> GetContacts();
        Contact GetContactById(int id); 
        bool Add(Contact contact);
        bool UpdateContact(ContactDto contactDto, int id);
        bool Remove(int id);
       
    }
}
