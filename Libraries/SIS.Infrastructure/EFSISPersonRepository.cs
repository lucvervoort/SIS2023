using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;

namespace SIS.Infrastructure
{
    public class EFSISPersonRepository : ISISPersonRepository
    {
        private readonly ILogger<EFSISPersonRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<string, Person> _persons;
        public Dictionary<string, Person> Persons
        {
            get
            {
                if (_persons != null) return _persons;
                return RefreshPersons();
            }
        }

        public Dictionary<string, Person> RefreshPersons()
        {
            _persons = new();
            var dbPeople = _context.People.ToList();
            foreach (var p in dbPeople)
            {
                var person = new Person
                {
                    Email = string.IsNullOrEmpty(p.Email) ? p.Email : p.Email,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Mobile = string.IsNullOrEmpty(p.Mobile) ? p.Mobile : p.Mobile,
                    Phone = p.Phone
                };
                _persons.Add(p.FirstName + " " + p.LastName, person);
            }
            return _persons;
        }

        public EFSISPersonRepository(ILogger<EFSISPersonRepository> logger, IConfiguration configuration, ILoggerFactory loggerFactory, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all teachers up front
            RefreshPersons();
        }

        public void Insert(Person person)
        {
            EFRepository.Models.Person newPerson = new()
            {
                Email = person.Email,
                FirstName = person.FirstName,
                LastName = person.LastName,
                SortName = string.Concat(person.LastName.ToUpperInvariant(), person.FirstName.ToUpperInvariant())
            };
            var efPerson = _context.People.Add(newPerson).Entity;
            var count = _context.SaveChanges();
            if(count == 1)
            {
                _persons.Add(person.FirstName + " " + person.LastName, person);
            }
        }

        public void Update(Person person)
        {
            // Test if person already present
            // Adapt person if needed
            throw new NotImplementedException();
        }

        public void Delete(Person person)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Person person)
        {
            throw new NotImplementedException();
        }
    }
}