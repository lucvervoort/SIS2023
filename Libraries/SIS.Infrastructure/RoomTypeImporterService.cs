using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class RoomTypeImporterService : IImporter
    {
        private readonly ILogger<RoomTypeImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISRoomTypeRepository _repository;

        public RoomTypeImporterService(ILogger<RoomTypeImporterService> logger, IConfiguration configuration, ISISRoomTypeRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "RoomType.json"));
            var roomType = JsonConvert.DeserializeObject<List<RoomType>>(json);
            if (roomType != null)
            {
                foreach (var rmt in roomType)
                {
                    _repository.Insert(rmt);
                }
            }
        }
    }
}