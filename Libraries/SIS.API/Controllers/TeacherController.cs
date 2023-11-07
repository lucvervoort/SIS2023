using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using SIS.Domain.Interfaces;
using AutoMapper;
using SIS.Domain;
using System.Net.Mime;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
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

        [HttpPost]
        public ActionResult<TeacherDTO> Create(TeacherDTO teacherDto)
        {
            try
            {
                if (teacherDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<Teacher>(teacherDto));
                return CreatedAtAction(nameof(Create), teacherDto);
            }
            catch(Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}