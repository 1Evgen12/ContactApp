using ContactApp.API.ModelDto;
using ContactApp.Model;
using Microsoft.Data.Sqlite;

namespace ContactApp.API.Storage
{
    public class SqliteStorage : IStorage
    {
        public List<Contact> GetContacts()
        {
            var contacts = new List<Contact>();
            string connectionString = "Data Source=API/contacts.db";
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM contacts";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                contacts.Add(new Contact()
                {
                    ID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2),
                    PhoneNumber = reader.IsDBNull(3)?null:reader.GetString(3),
                    Address = reader.IsDBNull(3) ? null : reader.GetString(4)
                });
            }

            return contacts;
        }
        public Contact GetContactById(int id)
        {
            throw new NotImplementedException();
        }
        public bool Add(Contact contact)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContact(ContactDto contactDto, int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
