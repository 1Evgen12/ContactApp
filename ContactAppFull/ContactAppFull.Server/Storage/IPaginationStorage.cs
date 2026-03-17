using ContactAppFull.Server.Model;

namespace ContactAppFull.Server.Storage
{
    public interface IPaginationStorage:IStorage
    {
        Contact GetContactById(int id);
    }
}
