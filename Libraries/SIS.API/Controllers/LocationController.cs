using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using SIS.API.DTO;
using System.Net.Mime;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ISISLocationRepository _repository;
        private readonly IMapper _mapper;

        public LocationController(ILogger<LocationController> logger, ISISLocationRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LocationDTO>> Get()
        {
            return Ok(_mapper.Map<List<LocationDTO>>(_repository.Locations.Values.ToList()));
        }

        [HttpGet("LocationName", Name = "locationName")]
        public ActionResult<IEnumerable<String>> GetName()
        {
            var locations = _mapper.Map<List<LocationDTO>>(_repository.Locations.Values.ToList());
            var name = locations.Select(lc => lc.Name);
            return Ok(name);
        }

        [HttpDelete(Name = "DeleteLocation")]
        public ActionResult Delete(int id)
        {
            var locationToDelete = _repository.Locations.Values.FirstOrDefault(lc => lc.LocationId == id);
            if (locationToDelete == null)
            {
                return NotFound();
            }

            _repository.Delete(locationToDelete);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([Required] int id, [FromBody][Required] LocationDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var locationToUpdate = _repository.Locations.Values.FirstOrDefault(lc => lc.LocationId == id);

            //UPDATE
            _repository.Update(locationToUpdate, _mapper.Map<Location>(dto));
            return Ok("Location has succesfully been updated."); ;
        }



        [HttpPost]
        public IActionResult Post([FromBody][Required] LocationDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var LocationToCreate = _mapper.Map<Location>(dto);

            //INSERT
            _repository.Insert(_mapper.Map<Location>(dto));
            //return CreatedAtAction("New Location has succesfully been added.", dto);
            return CreatedAtAction(nameof(Get), new { id = 1 }, dto);
            // return Ok();
        }
        private bool IsValid(LocationDTO dto)
        {
            if (dto == null ||
                (dto.LocationId == 0 &&
                dto.Name == null && 
                dto.CampusId == 0 ))
            { return false; }
            return true;
        }
    }
}
