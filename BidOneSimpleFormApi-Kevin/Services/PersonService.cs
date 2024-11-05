using System.Text.Json;
using BidOneSimpleFormApi_Kevin.DataAccess.Models;

namespace BidOneSimpleFormApi_Kevin.Services
{
    public class PersonService
    {
        private readonly string filePath = "people.json";

        public async Task<Person> AddPersonAsync(Person person)
        {
            person.Id = Guid.NewGuid();
            var jsonData = JsonSerializer.Serialize(person);
            await File.AppendAllTextAsync(filePath, jsonData + Environment.NewLine);
            return person;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            if (!File.Exists(filePath)) return Enumerable.Empty<Person>();

            var lines = File.ReadAllLines(filePath);
            var persons = lines.Select(line => JsonSerializer.Deserialize<Person>(line)).ToList();
            return persons;
        }

        public Person GetPersonById(Guid id)
        {
            if (!File.Exists(filePath)) return null;

            var lines = File.ReadAllLines(filePath);
            var person = lines
                .Select(line => JsonSerializer.Deserialize<Person>(line))
                .FirstOrDefault(p => p.Id == id);
            return person;
        }
    }
}
