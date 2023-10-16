using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class TeacherImporterService : IImporter
    {
        private readonly ILogger<TeacherImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISRepository _repository;

        public TeacherImporterService(ILogger<TeacherImporterService> logger, IConfiguration configuration, ISISRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "Teacheren.json"));
            var lectoren = JsonConvert.DeserializeObject<List<Teacher>>(json);
            foreach (var l in lectoren)
            {
                _repository.Add(l);
            }
            _repository.SaveChanges();
        }
    }
}