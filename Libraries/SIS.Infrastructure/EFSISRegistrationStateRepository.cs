using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;

namespace SIS.Infrastructure
{
    public class EFSISRegistrationStateRepository : ISISRegistrationStateRepository
    {
        private readonly ILogger<EFSISRegistrationStateRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<string, RegistrationState> _registrationStates;
        public Dictionary<string, RegistrationState> RegistrationStates
        {
            get
            {
                if (_registrationStates != null) return _registrationStates;
                return RefreshRegistrationStates();
            }
        }

        public EFSISRegistrationStateRepository(ILogger<EFSISRegistrationStateRepository> logger, IConfiguration configuration, ILoggerFactory loggerFactory, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all teachers up front
            RefreshRegistrationStates();
        }

        public Dictionary<string, RegistrationState> RefreshRegistrationStates()
        {
            _registrationStates = new();
            var dbRegistrationStates = _context.RegistrationStates.ToList(); // ToList not to have multiple open readers, Include to eager load
            foreach (var registrationState in dbRegistrationStates)
            {
                var newTeacherType = new RegistrationState
                {
                    Description = registrationState.Description
                };
                _registrationStates.Add(registrationState.Description, newTeacherType);
            }
            return _registrationStates;
        }

        public void Insert(RegistrationState registrationState)
        {
            var efRegistrationState = _context.RegistrationStates.Where(t => t.Description == registrationState.Description).FirstOrDefault();
            if (efRegistrationState == null)
            {
                EFRepository.Models.RegistrationState newRegistrationState = new()
                {
                    Description = registrationState.Description
                };
                efRegistrationState = _context.RegistrationStates.Add(newRegistrationState).Entity;
                var count = _context.SaveChanges();
                if(count == 1)
                {
                    _registrationStates.Add(registrationState.Description, registrationState);
                }
            }
        }

        public void Update(RegistrationState registrationState)
        {
            throw new NotImplementedException();
        }

        public void Delete(RegistrationState registrationState)
        {
            throw new NotImplementedException();
        }

        public bool Exists(RegistrationState registrationState)
        {
            throw new NotImplementedException();
        }
    }
}