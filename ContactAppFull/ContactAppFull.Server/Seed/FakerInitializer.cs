using Bogus;
using ContactAppFull.Server.Model;
using Microsoft.Data.Sqlite;

namespace ContactAppFull.Server.Seed
{
    public class FakerInitializer : IInitializer
    {
        private string connectionString;

        public FakerInitializer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Initialize()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = $"CREATE TABLE IF NOT EXISTS contacts( " +
                $"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                $"name TEXT NOT NULL, " +
                $"email TEXT NOT NULL, " +
                $"phone TEXT, " +
                $"address TEXT);";
            command.ExecuteNonQuery();
            command.CommandText = $"SELECT count(*) FROM contacts;";
            long count = (long)command.ExecuteScalar();
            if(count == 0)
            {
                var faker = new Faker<Contact>("ru")
                    .RuleFor(c => c.Name, f => f.Name.FullName())
                    .RuleFor(c => c.Email, f => f.Internet.Email())
                    .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                    .RuleFor(c => c.Address, f => f.Address.FullAddress());

                var contacts = faker.Generate(10);

                foreach (var contact in contacts)
                {
                    command.CommandText = $"INSERT INTO contacts(name, email, phone, address)" +
                        $"VALUES (@name, @email, @phone, @address)";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@name", contact.Name);
                    command.Parameters.AddWithValue("@email", contact.Email);
                    command.Parameters.AddWithValue("@phone", contact.PhoneNumber);
                    command.Parameters.AddWithValue("@address", contact.Address);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
