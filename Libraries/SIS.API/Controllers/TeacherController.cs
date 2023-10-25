using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using SIS.Domain.Interfaces;
using AutoMapper;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ILogger<TeacherController> _logger;
        private readonly ISISTeacherRepository _repository;
        private readonly IMapper _mapper;

        public TeacherController(ILogger<TeacherController> logger, ISISTeacherRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetTeachers")]
        public ActionResult<IEnumerable<TeacherDTO>> Get()
        {
            /*
            var dtos = _repository.Teachers.Values.Select(t => new TeacherDTO
            {
                FirstName = t.FirstName, 
                LastName = t.LastName
            })
            .ToArray();
            return Ok(dtos);
            */
            return Ok(_mapper.Map<List<TeacherDTO>>(_repository.Teachers.Values.ToList()));
        }
    }
}