using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;
using System.Data;

namespace SIS.Infrastructure
{
    public class LectorImporterService : IImporter
    {
        private readonly ILogger<LectorImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISRepository _repository;

        public LectorImporterService(ILogger<LectorImporterService> logger, IConfiguration configuration, ISISRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "Lectoren.json"));
            var lectoren = JsonConvert.DeserializeObject<List<Lector>>(json);
            //var repository = new SISRepository(_logger, _configuration);
            foreach (var l in lectoren)
            {
                _repository.Add(l);
            }
            _repository.SaveChanges();
        }
    }
}