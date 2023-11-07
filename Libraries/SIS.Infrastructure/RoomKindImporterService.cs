using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class RoomKindImporterService : IImporter
    {
        private readonly ILogger<RoomKindImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISRoomKindRepository _repository;

        public RoomKindImporterService(ILogger<RoomKindImporterService> logger, IConfiguration configuration, ISISRoomKindRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "RoomKind.json"));
            var roomKind = JsonConvert.DeserializeObject<List<RoomKind>>(json);
            if (roomKind != null)
            {
                foreach (var rmk in roomKind)
                {
                    _repository.Insert(rmk);
                }
            }
        }
    }
}