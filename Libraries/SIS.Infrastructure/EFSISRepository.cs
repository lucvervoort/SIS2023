using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;

namespace SIS.Infrastructure
{
    public class EFSISRepository : ISISRepository
    {
        private readonly ILogger<EFSISRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<string, Teacher> _lectors;
        public Dictionary<string, Teacher> Teachers
        {
            get
            {
                if (_lectors != null) return _lectors;
                return RefreshTeachers();
            }
        }

        public Dictionary<string, Teacher> RefreshTeachers()
        {
            _lectors = new();
            var dbTeachers = _context.Teachers.Include(l => l.RegistrationState).Include(l => l.TeacherType).ToList(); // ToList not to have multiple open readers, Include to eager load
            var dbPeople = _context.People.ToList();
            foreach (var lector in dbTeachers)
            {
                var p = dbPeople.Where(person => person.PersonId == lector.PersonId).FirstOrDefault();
                if (p != null)
                {
                    var l = new Teacher 
                    { 
                        Abbreviation = lector.Abbreviation, 
                        Email = string.IsNullOrEmpty(lector.Email) ? p.Email : lector.Email, 
                        FirstName = p.FirstName, 
                        LastName = p.LastName, 
                        Mobile = string.IsNullOrEmpty(lector.Mobile) ? p.Mobile : lector.Mobile, 
                        Phone = p.Phone, 
                        Type = lector.TeacherType.Description, 
                        RegistrationState = lector.RegistrationState.Description 
                    };
                    _lectors.Add(p.FirstName + " " + p.LastName, l);
                }
            }
            return _lectors;
        }

        public EFSISRepository(ILogger<EFSISRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _context = new SisDbContext(_configuration);
        }

        public void Add(Teacher lector)
        {
            // TODO
            // Test if lector is already present in dictionary
            // If not, add lector to dictionary and update database...
            EFRepository.Models.Person newPerson = new() { };
            EFRepository.Models.Teacher newTeacher = new() { };
            // Test if person already present
            // Adapt person if needed
            // Fetch identity id
            _context.People.Add(newPerson);
            // Test if lector already present
            // Adapt lector if needed            
            _context.Teachers.Add(newTeacher);
        }

        public void SaveChanges()
        {
            // Update database
            _context.SaveChanges();
        }
    }
}