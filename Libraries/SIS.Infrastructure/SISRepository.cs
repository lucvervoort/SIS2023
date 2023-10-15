using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;

namespace SIS.Infrastructure
{
    public class SISRepository : ISISRepository
    {
        private readonly ILogger<SISRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<string, Lector> _lectors;
        public Dictionary<string, Lector> Lectors
        {
            get
            {
                if (_lectors != null) return _lectors;
                return RefreshLectors();
            }
        }

        public Dictionary<string, Lector> RefreshLectors()
        {
            _lectors = new();
            var dbLectors = _context.Lectors.Include(l => l.RegistrationState).Include(l => l.LectorType).ToList(); // ToList not to have multiple open readers, Include to eager load
            var dbPeople = _context.People.ToList();
            foreach (var lector in dbLectors)
            {
                var p = dbPeople.Where(person => person.PersonId == lector.PersonId).FirstOrDefault();
                if (p != null)
                {
                    var l = new Lector 
                    { 
                        Abbreviation = lector.Abbreviation, 
                        Email = string.IsNullOrEmpty(lector.Email) ? p.Email : lector.Email, 
                        FirstName = p.FirstName, 
                        LastName = p.LastName, 
                        Mobile = string.IsNullOrEmpty(lector.Mobile) ? p.Mobile : lector.Mobile, 
                        Phone = p.Phone, 
                        Type = lector.LectorType.Description, 
                        RegistrationState = lector.RegistrationState.Description 
                    };
                    _lectors.Add(p.FirstName + " " + p.LastName, l);
                }
            }
            return _lectors;
        }

        public SISRepository(ILogger<SISRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _context = new SisDbContext(_configuration);
        }

        public void Add(Lector lector)
        {
            // TODO
            // Test if lector is already present in dictionary
            // If not, add lector to dictionary and update database...
            EFRepository.Models.Person newPerson = new() { };
            EFRepository.Models.Lector newLector = new() { };
            // Test if person already present
            // Adapt person if needed
            // Fetch identity id
            _context.People.Add(newPerson);
            // Test if lector already present
            // Adapt lector if needed            
            _context.Lectors.Add(newLector);
        }

        public void SaveChanges()
        {
            // Update database
            _context.SaveChanges();
        }
    }
}