using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using SIS.Domain.Interfaces;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly ISISRepository _repository;

        public TeacherController(ILogger<TeacherController> logger, ISISRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetTeachers")]
        public IEnumerable<TeacherDTO> Get()
        {
            var dtos = _repository.Teachers.Values.Select(t => new TeacherDTO
            {
                FirstName = t.FirstName, 
                LastName = t.LastName
            })
            .ToArray();
            return dtos;
        }
    }
}