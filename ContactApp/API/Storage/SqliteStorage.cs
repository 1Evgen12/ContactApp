using ContactApp.API.ModelDto;
using ContactApp.Model;
using Microsoft.Data.Sqlite;
using System.Text;

namespace ContactApp.API.Storage
{
    public class SqliteStorage : IStorage
    {
        string connectionString = "Data Source=API/contacts.db";

        public List<Contact> GetContacts()
        {
            var contacts = new List<Contact>();
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
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            //string sql = new StringBuilder()
            //.Append("INSERT INTO contacts(name, email, phone, address) VALUES")
            //    .Append($"('{contact.Name}','{contact.Email}','{contact.PhoneNumber}','{contact.Address}');").ToString();
            string sql = "INSERT INTO contacts(name, email, phone, address) VALUES (@name, @email, @phone, @address);";
            command.CommandText = sql;
            command.Parameters.AddWithValue("@name", contact.Name);
            command.Parameters.AddWithValue("@email", contact.Email);
            command.Parameters.AddWithValue("@phone", contact.PhoneNumber);
            command.Parameters.AddWithValue("@address", contact.Address);
            Console.WriteLine("sql >> "+sql);
            return command.ExecuteNonQuery()>0;
        }

        public bool UpdateContact(ContactDto contactDto, int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            string sql = $"DELETE FROM contacts WHERE id = {id}";
            command.CommandText = sql;
            return command.ExecuteNonQuery()>0;
        }

        
    }
}
