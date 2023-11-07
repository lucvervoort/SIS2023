using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public class RoomTypeController : ControllerBase
    {
        private readonly ILogger<RoomTypeController> _logger;
        private readonly ISISRoomTypeRepository _repository;
        private readonly IMapper _mapper;

        public RoomTypeController(ILogger<RoomTypeController> logger, ISISRoomTypeRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomTypeDTO>> Get()
        {
            return Ok(_mapper.Map<List<RoomTypeDTO>>(_repository.RoomTypes.Values.ToList()));
        }

        [HttpGet("RoomTypeName", Name = "RoomTypeName")]
        public ActionResult<IEnumerable<String>> GetName()
        {
            var roomTypes = _mapper.Map<List<RoomTypeDTO>>(_repository.RoomTypes.Values.ToList());
            var name = roomTypes.Select(rmt => rmt.Name);
            return Ok(name);
        }

        [HttpDelete(Name = "DeleteRoomType")]
        public ActionResult Delete(int id)
        {
            var roomTypeToDelete = _repository.RoomTypes.Values.FirstOrDefault(rmt => rmt.RoomTypeId == id);
            if (roomTypeToDelete == null)
            {
                return NotFound();
            }

            _repository.Delete(roomTypeToDelete);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([Required] int id, [FromBody][Required] RoomTypeDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var roomTypeToUpdate = _repository.RoomTypes.Values.FirstOrDefault(rmt => rmt.RoomTypeId == id);

            //UPDATE
            _repository.Update(roomTypeToUpdate, _mapper.Map<RoomType>(dto));
            return Ok("RoomType has succesfully been updated."); ;
        }



        [HttpPost]
        public IActionResult Post([FromBody][Required] RoomTypeDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var RoomTypeToCreate = _mapper.Map<RoomType>(dto);

            //INSERT
            _repository.Insert(_mapper.Map<RoomType>(dto));
            //return CreatedAtAction("New RoomType has succesfully been added.", dto);
            return CreatedAtAction(nameof(Get), new { id = 1 }, dto);
            // return Ok();
        }


        private bool IsValid(RoomTypeDTO dto)
        {
            if (dto == null || (dto.RoomTypeId == 0 && dto.Name == null))
            { 
                return false; 
            }
            return true;
        }
    }
}
