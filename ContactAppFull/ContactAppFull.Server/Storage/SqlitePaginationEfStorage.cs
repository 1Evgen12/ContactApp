using ContactAppFull.Server.DataContext;
using ContactAppFull.Server.Model;

namespace ContactAppFull.Server.Storage
{
    public class SqlitePaginationEfStorage:SqliteEfStorage, IPaginationStorage
    {
        public SqlitePaginationEfStorage(SqliteDbContext context):base(context)
        {
            
        }

        public Contact GetContactById(int id)
        {
            return base.context.Contacts.Find(id);
        }
    }
}
