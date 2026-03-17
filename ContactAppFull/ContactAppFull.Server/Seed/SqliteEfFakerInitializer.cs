using Bogus;
using Bogus.DataSets;
using ContactAppFull.Server.DataContext;
using ContactAppFull.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactAppFull.Server.Seed
{
    public class SqliteEfFakerInitializer : IInitializer
    {
        private readonly SqliteDbContext context;

        public SqliteEfFakerInitializer(SqliteDbContext context)
        {
            this.context = context;
        }

        private string GenerateEmailForName(string name)
        {
            string email = Transliterater.Translate(name)
                .ToLower().Replace(" ", ".") + "@example.ru";
            return email;
        }

        public void Initialize()
        {
            context.Database.Migrate();
            if (!context.Contacts.Any())
            {
                var faker = new Faker<Contact>("ru")
                    .RuleFor(c => c.Name, f => f.Name.FullName())
                    .RuleFor(c => c.Email, (f,c) => GenerateEmailForName(c.Name))
                    .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                    .RuleFor(c => c.Address, f => f.Address.FullAddress());

                var contacts = faker.Generate(10);
                context.Contacts.AddRange(contacts);
                context.SaveChanges();
            }
        }
    }
}
    