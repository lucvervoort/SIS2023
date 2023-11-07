using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using SIS.Domain;
using SIS.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
    public class TeacherPreferenceController : ControllerBase
    {
        private readonly ILogger<TeacherPreferenceController> _logger;
        private readonly ISISTeacherPreferenceRepository _repository;
        private readonly IMapper _mapper;

        public TeacherPreferenceController(ILogger<TeacherPreferenceController> logger, ISISTeacherPreferenceRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeacherPreferenceDTO>> Get()
        {
            return Ok(_mapper.Map<List<TeacherPreferenceDTO>>(_repository.TeacherPreferences.Values.ToList()));
        }

        [HttpGet("Descriptions", Name = "Descriptions")]
        public ActionResult<IEnumerable<String>> GetDescriptions()
        {
            var preferences = _mapper.Map<List<TeacherPreferenceDTO>>(_repository.TeacherPreferences.Values.ToList());
            var descriptions = preferences.Select(tp => tp.Description);
            return Ok(descriptions);
        }

        [HttpDelete(Name = "Delete")]
        public ActionResult Delete(int id)
        {
            var teacherPreferenceToDelete = _repository.TeacherPreferences.Values.FirstOrDefault(tp => tp.TeacherPreferenceId == id);
            if (teacherPreferenceToDelete == null)
            {
                return NotFound();
            }

            _repository.Delete(teacherPreferenceToDelete);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([Required] int id, [FromBody] [Required] TeacherPreferenceDTO dto )
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var teacherPreferenceToUpdate = _repository.TeacherPreferences.Values.FirstOrDefault(tp => tp.TeacherPreferenceId == id);

            //UPDATE
            _repository.Update(teacherPreferenceToUpdate, _mapper.Map<TeacherPreference>(dto));
            return Ok("Teacher Preference has succesfully been updated."); ;
        }



        [HttpPost]
        public IActionResult Post([FromBody][Required] TeacherPreferenceDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var teacherPreferenceToCreate = _mapper.Map<TeacherPreference>(dto);

            //INSERT
            _repository.Insert(_mapper.Map<TeacherPreference>(dto));
            //return CreatedAtAction("New Teacher Preference has succesfully been added.", dto);
            return CreatedAtAction(nameof(Get), new { id = 1 }, dto);
            // return Ok();
        }


        private bool IsValid(TeacherPreferenceDTO dto)
        {
            if (dto == null ||
                (dto.Preference == 0
                && dto.Description == "string"
                && dto.TeacherPreferenceId == 0)) { return false; }
            return true;
        }

    }
}
