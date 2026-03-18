using ContactAppFull.Server.Model;

namespace ContactAppFull.Server.Storage
{
    public interface IPaginationStorage:IStorage
    {
        Contact GetContactById(int id);
        (List<Contact>, int TotalCount) GetContacts(int pageNumber, int pageSize);
    }
}
