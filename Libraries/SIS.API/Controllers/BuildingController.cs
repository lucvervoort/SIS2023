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
    public class BuildingController : ControllerBase
    {
        private readonly ILogger<BuildingController> _logger;
        private readonly ISISBuildingRepository _repository;
        private readonly IMapper _mapper;

        public BuildingController(ILogger<BuildingController> logger, ISISBuildingRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BuildingDTO>> Get()
        {
            return Ok(_mapper.Map<List<BuildingDTO>>(_repository.Buildings.Values.ToList()));
        }

        [HttpGet("BuildingName", Name = "BuildingName")]
        public ActionResult<IEnumerable<String>> GetName()
        {
            var buildings = _mapper.Map<List<BuildingDTO>>(_repository.Buildings.Values.ToList());
            var name = buildings.Select(bd => bd.Name);
            return Ok(name);
        }

        [HttpDelete(Name = "DeleteBuilding")]
        public ActionResult Delete(int id)
        {
            var buildingToDelete = _repository.Buildings.Values.FirstOrDefault(bd => bd.BuildingId == id);
            if (buildingToDelete == null)
            {
                return NotFound();
            }

            _repository.Delete(buildingToDelete);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([Required] int id, [FromBody][Required] BuildingDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var buildingToUpdate = _repository.Buildings.Values.FirstOrDefault(bd => bd.BuildingId == id);

            //UPDATE
            _repository.Update(buildingToUpdate, _mapper.Map<Building>(dto));
            return Ok("Building has succesfully been updated."); ;
        }



        [HttpPost]
        public IActionResult Post([FromBody][Required] BuildingDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var BuildingToCreate = _mapper.Map<Building>(dto);

            //INSERT
            _repository.Insert(_mapper.Map<Building>(dto));
            //return CreatedAtAction("New Building has succesfully been added.", dto);
            return CreatedAtAction(nameof(Get), new { id = 1 }, dto);
            // return Ok();
        }


        private bool IsValid(BuildingDTO dto)
        {
            if (dto == null ||
                (dto.BuildingId == 0 &&
                dto.LocationId == 0 &&
                dto.Name == null ))
            { return false; }
            return true;
        }
    }
}
