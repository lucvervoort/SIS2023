using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class TeacherPreferenceImporterService : IImporter
    {
        private readonly ILogger<TeacherPreferenceImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISTeacherPreferenceRepository _repository;

        public TeacherPreferenceImporterService(ILogger<TeacherPreferenceImporterService> logger, IConfiguration configuration, ISISTeacherPreferenceRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "TeacherPreference.json"));
            var teacherPreferences = JsonConvert.DeserializeObject<List<TeacherPreference>>(json);
            if (teacherPreferences != null)
            {
                foreach (var tp in teacherPreferences)
                {
                    _repository.Insert(tp); 
                }
            }
        }
    }
}