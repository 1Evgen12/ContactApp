using ContactAppFull.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactAppFull.Server.DataContext
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options)
            :base(options)
        {
            
        }
    }
}
