using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class BuildingImporterService : IImporter
    {
        private readonly ILogger<BuildingImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISBuildingRepository _repository;

        public BuildingImporterService(ILogger<BuildingImporterService> logger, IConfiguration configuration, ISISBuildingRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "Building.json"));
            var building = JsonConvert.DeserializeObject<List<Building>>(json);
            if (building != null)
            {
                foreach (var bd in building)
                {
                    _repository.Insert(bd);
                }
            }
        }
    }
}