using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using SIS.API.DTO;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
    public class CampusController : ControllerBase
    {
        private readonly ILogger<CampusController> _logger;
        private readonly ISISCampusRepository _repository;
        private readonly IMapper _mapper;

        public CampusController(ILogger<CampusController> logger, ISISCampusRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;            
        }

        /// <summary>
        /// Een overzicht van alle campussen
        /// </summary>
        /// <returns></returns>
        [HttpGet]
#if ProducesConsumes
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable <CampusDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
#endif
        public ActionResult<IEnumerable<CampusDTO>> Get()
        {
            return Ok(_mapper.Map<List<CampusDTO>>(_repository.Campus.Values.ToList()));
        }

        [HttpGet("CampusName", Name = "CampusName")]
        public ActionResult<IEnumerable<String>> GetName()
        {
            var campus = _mapper.Map<List<CampusDTO>>(_repository.Campus.Values.ToList());
            var name = campus.Select(cmp => cmp.Name);
            return Ok(name);
        }

        [HttpDelete(Name = "DeleteCampus")]
#if ProducesConsumes
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
#endif
        public ActionResult Delete(int id)
        {
            var campusToDelete = _repository.Campus.Values.FirstOrDefault(cmp => cmp.CampusId == id);
            if (campusToDelete == null)
            {
                return NotFound();
            }

            _repository.Delete(campusToDelete);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([Required] int id, [FromBody][Required] CampusDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var campusToUpdate = _repository.Campus.Values.FirstOrDefault(cmp => cmp.CampusId == id);

            //UPDATE
            _repository.Update(campusToUpdate, _mapper.Map<Campus>(dto));
            return Ok("Campus has succesfully been updated.");
        }

        [HttpPost]
#if ProducesConsumes
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
#endif
        public IActionResult Post([FromBody][Required] CampusDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var campusToCreate = _mapper.Map<Campus>(dto);

            //INSERT
            var campus = _repository.Insert(_mapper.Map<Campus>(dto));
            dto.CampusId = campus.CampusId;
            return CreatedAtAction(nameof(Get), new { id = campus.CampusId }, dto);
        }


        private bool IsValid(CampusDTO dto)
        {
            if (dto == null ||
                (dto.CampusId == 0 &&
                dto.Name == null ))
            { return false; }
            return true;
        }
    }
}
