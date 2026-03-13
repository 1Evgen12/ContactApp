using ContactApp.API.Model;
using ContactApp.API.ModelDto;
using Microsoft.Data.Sqlite;

namespace ContactApp.API.Storage
{
    public class SqliteStorage : IStorage
    {
        private readonly string connectionString;

        public SqliteStorage(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
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
                    Address = reader.IsDBNull(4) ? null : reader.GetString(4)
                });
            }
            return contacts;
        }
        public Contact GetContactById(int id)
        {
            Contact contact=new Contact();
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM contacts WHERE id = {id}";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                contact.ID = reader.GetInt32(0);
                contact.Name = reader.GetString(1);
                contact.Email = reader.GetString(2);
                contact.PhoneNumber = reader.IsDBNull(3) ? null : reader.GetString(3);
                contact.Address = reader.IsDBNull(4) ? null : reader.GetString(4);              
            }

            return contact;
        }
        public bool Add(Contact contact)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();          
            string sql = "INSERT INTO contacts(name, email, phone, address) VALUES (@name, @email, @phone, @address);";
            command.CommandText = sql;
            command.Parameters.AddWithValue("@name", contact.Name);
            command.Parameters.AddWithValue("@email", contact.Email);
            command.Parameters.AddWithValue("@phone", contact.PhoneNumber);
            command.Parameters.AddWithValue("@address", contact.Address);
            //Console.WriteLine("sql >> "+sql);
            return command.ExecuteNonQuery()>0;
        }

        public bool UpdateContact(ContactDto contactDto, int id)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            string sql = "UPDATE contacts " +
                "SET name=@name, email=@email, phone=@phone, address=@address " +
                "WHERE id = @id;";
            command.CommandText = sql;
            command.Parameters.AddWithValue("@name", contactDto.Name);
            command.Parameters.AddWithValue("@email", contactDto.Email);
            command.Parameters.AddWithValue("@phone", contactDto.PhoneNumber);
            command.Parameters.AddWithValue("@address", contactDto.Address);
            command.Parameters.AddWithValue("@id", id);

            return command.ExecuteNonQuery()>0;            
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
