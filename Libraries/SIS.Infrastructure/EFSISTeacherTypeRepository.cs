using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;

namespace SIS.Infrastructure
{
    public class EFSISTeacherTypeRepository : ISISTeacherTypeRepository
    {
        private readonly ILogger<EFSISTeacherTypeRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<string, TeacherType> _teacherTypes;
        public Dictionary<string, TeacherType> TeacherTypes
        {
            get
            {
                if (_teacherTypes != null) return _teacherTypes;
                return RefreshTeacherTypes();
            }
        }

        public EFSISTeacherTypeRepository(ILogger<EFSISTeacherTypeRepository> logger, IConfiguration configuration, ILoggerFactory loggerFactory, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all teachers up front
            RefreshTeacherTypes();
        }

        public Dictionary<string, TeacherType> RefreshTeacherTypes()
        {
            _teacherTypes = new();
            var dbTeacherTypes = _context.TeacherTypes.ToList(); // ToList not to have multiple open readers, Include to eager load
            foreach (var teacherType in dbTeacherTypes)
            {
                var newTeacherType  = new TeacherType
                {
                    Description = teacherType.Description
                };
                _teacherTypes.Add(teacherType.Description, newTeacherType);
            }
            return _teacherTypes;
        }

        public void Insert(TeacherType teacherType)
        {
            var efTeacherType = _context.TeacherTypes.Where(t => t.Description == teacherType.Description).FirstOrDefault();
            if (efTeacherType == null)
            {
                EFRepository.Models.TeacherType newTeacherType = new()
                {
                    Description = teacherType.Description
                };
                efTeacherType = _context.TeacherTypes.Add(newTeacherType).Entity;
                var count = _context.SaveChanges();
            }
        }

        public void Update(TeacherType teacherType)
        {
            throw new NotImplementedException();
        }

        public void Delete(TeacherType teacherType)
        {
            throw new NotImplementedException();
        }

        public bool Exists(TeacherType teacherType)
        {
            throw new NotImplementedException();
        }
    }
}