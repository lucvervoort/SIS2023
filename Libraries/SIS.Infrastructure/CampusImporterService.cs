using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class CampusImporterService : IImporter
    {
        private readonly ILogger<CampusImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISCampusRepository _repository;

        public CampusImporterService(ILogger<CampusImporterService> logger, IConfiguration configuration, ISISCampusRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "Campus.json"));
            var campus = JsonConvert.DeserializeObject<List<Campus>>(json);
            if (campus != null)
            {
                foreach (var cmp in campus)
                {
                    _repository.Insert(cmp);
                }
            }
        }
    }
}