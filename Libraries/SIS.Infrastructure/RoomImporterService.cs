using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SIS.Domain;
using SIS.Domain.Interfaces;

namespace SIS.Infrastructure
{
    public class RoomImporterService : IImporter
    {
        private readonly ILogger<RoomImporterService> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISISRoomRepository _repository;

        public RoomImporterService(ILogger<RoomImporterService> logger, IConfiguration configuration, ISISRoomRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
        }

        public void Import()
        {
            string json = File.ReadAllText(Path.Combine(_configuration["JsonDataPath"], "Room.json"));
            var room = JsonConvert.DeserializeObject<List<Room>>(json);
            if (room != null)
            {
                foreach (var rm in room)
                {
                    _repository.Insert(rm);
                }
            }
        }
    }
}