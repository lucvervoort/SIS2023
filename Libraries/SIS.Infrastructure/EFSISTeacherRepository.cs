using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;

namespace SIS.Infrastructure
{
    public class EFSISTeacherRepository : ISISTeacherRepository
    {
        private readonly ILogger<EFSISTeacherRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private readonly ISISPersonRepository _personRepository;
        private readonly ISISTeacherTypeRepository _teacherTypeRepository;
        private readonly ISISRegistrationStateRepository _registrationStateRepository;

        private Dictionary<string, Teacher> _teachers;
        public Dictionary<string, Teacher> Teachers
        {
            get
            {
                if (_teachers != null) return _teachers;
                return RefreshTeachers();
            }
        }

        public EFSISTeacherRepository(ILogger<EFSISTeacherRepository> logger, IConfiguration configuration, ISISPersonRepository personRepository, ISISTeacherTypeRepository teacherTypeRepository, ISISRegistrationStateRepository registrationStateRepository, ILoggerFactory loggerFactory, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            _personRepository = personRepository;
            _teacherTypeRepository = teacherTypeRepository;
            _registrationStateRepository = registrationStateRepository;

            // Load all teachers up front
            RefreshTeachers();
        }

        public Dictionary<string, Teacher> RefreshTeachers()
        {
            _teachers = new();
            var dbTeachers = _context.Teachers.Include(l => l.RegistrationState).Include(l => l.TeacherType).Include(l => l.Person).ToList(); // ToList not to have multiple open readers, Include to eager load
            foreach (var teacher in dbTeachers)
            {
                var p = _personRepository.Persons.Values.Where(person => person.FirstName == teacher.Person.FirstName && person.LastName == teacher.Person.LastName).FirstOrDefault();
                if (p == null)
                {
                    p = new Person { FirstName = teacher.Person.FirstName, LastName = teacher.Person.LastName };
                    _personRepository.Insert(p);
                }
                var l = new Teacher
                {
                    Abbreviation = teacher.Abbreviation,
                    Email = string.IsNullOrEmpty(teacher.Email) ? p.Email : teacher.Email,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Mobile = string.IsNullOrEmpty(teacher.Mobile) ? p.Mobile : teacher.Mobile,
                    Phone = p.Phone,
                    Type = teacher.TeacherType.Description,
                    RegistrationState = teacher.RegistrationState.Description
                };
                _teachers.Add(p.FirstName + " " + p.LastName, l);
            }
            return _teachers;
        }

        // Move the next example code to a better place:
        public IEnumerable<string> GetNames()
        {
            var result = _context.TeacherNameDTO.FromSqlRaw(@"SELECT CONCAT(P.FirstName, ' ', P.LastName) AS Name, CAST(0 AS BIT) AS IsDeleted FROM Teacher T FULL OUTER JOIN Person P ON T.PersonId = P.PersonId");
            List<string> names = new();
            names.AddRange(from t in result select t.Name);
            return names;
        }

        public void Insert(Teacher teacher)
        {
            if (_teachers.ContainsKey(teacher.FirstName + " " + teacher.LastName))
                return;

            // Test if Person already exists...
            var person = _personRepository.Persons.Values.Where(person => person.FirstName == teacher.FirstName && person.LastName == teacher.LastName).FirstOrDefault();
            if (person == null)
            {
                person = new Person { FirstName = teacher.FirstName, LastName = teacher.LastName };
                _personRepository.Insert(person);
            }
            var efPerson = _context.People.Where(person => person.FirstName == teacher.FirstName && person.LastName == teacher.LastName).FirstOrDefault();
            var teacherType = _teacherTypeRepository.TeacherTypes.Values.Where(tt => tt.Description == teacher.Type).FirstOrDefault();
            if(teacherType == null)
            {
                teacherType = new TeacherType { Description = teacher.Type };
                _teacherTypeRepository.Insert(teacherType);
            }
            var efTeacherType = _context.TeacherTypes.Where(tt => tt.Description == teacher.Type).FirstOrDefault();
            var registrationState = _registrationStateRepository.RegistrationStates.Values.Where(tt => tt.Description == teacher.RegistrationState).FirstOrDefault();
            if (registrationState == null)
            {
                registrationState = new RegistrationState { Description = teacher.RegistrationState };
                _registrationStateRepository.Insert(registrationState);
            }
            var efRegistrationState = _context.RegistrationStates.Where(tt => tt.Description == teacher.RegistrationState).FirstOrDefault();
            if (efPerson != null && efTeacherType != null && efRegistrationState != null)
            {
                EFRepository.Models.Teacher newTeacher = new()
                {
                    Email = teacher.Email,
                    Abbreviation = teacher.Abbreviation,
                    Person = efPerson,
                    PersonId = efPerson.PersonId,
                    TeacherType = efTeacherType,
                    TeacherTypeId = efTeacherType.TeacherTypeId
                };
                var efTeacher = _context.Teachers.Add(newTeacher).Entity;
                var count = _context.SaveChanges();
                _teachers.Add(teacher.FirstName + " " + teacher.LastName, teacher);
            }
        }

        public void Update(Teacher teacher)
        {
            // Test if teacher already present
            // Adapt person if needed
            throw new NotImplementedException();
        }

        public void Delete(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}