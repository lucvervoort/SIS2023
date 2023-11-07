using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class LocationImporterService : IImporter
    {
        private readonly ILogger<LocationImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISLocationRepository _repository;

        public LocationImporterService(ILogger<LocationImporterService> logger, IConfiguration configuration, ISISLocationRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "Location.json"));
            var location = JsonConvert.DeserializeObject<List<Location>>(json);
            if (location != null)
            {
                foreach (var lc in location)
                {
                    _repository.Insert(lc);
                }
            }
        }
    }
}