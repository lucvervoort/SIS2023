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
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly ISISRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomController(ILogger<RoomController> logger, ISISRoomRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomDTO>> Get()
        {
            return Ok(_mapper.Map<List<RoomDTO>>(_repository.Rooms.Values.ToList()));
        }

        [HttpGet("RoomName", Name = "RoomName")]
        public ActionResult<IEnumerable<String>> GetName()
        {
            var rooms = _mapper.Map<List<RoomDTO>>(_repository.Rooms.Values.ToList());
            var name = rooms.Select(rm => rm.Name);
            return Ok(name);
        }

        [HttpDelete(Name = "DeleteRoom")]
        public ActionResult Delete(int id)
        {
            var roomToDelete = _repository.Rooms.Values.FirstOrDefault(rm => rm.RoomId == id);
            if (roomToDelete == null)
            {
                return NotFound();
            }

            _repository.Delete(roomToDelete);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([Required] int id, [FromBody] [Required] RoomDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var roomToUpdate = _repository.Rooms.Values.FirstOrDefault(rm => rm.RoomId == id);

            //UPDATE
            _repository.Update(roomToUpdate, _mapper.Map<Room>(dto));
            return Ok("Room has succesfully been updated."); ;
        }



        [HttpPost]
        public IActionResult Post([FromBody][Required] RoomDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var RoomToCreate = _mapper.Map<Room>(dto);

            //INSERT
            _repository.Insert(_mapper.Map<Room>(dto));
            //return CreatedAtAction("New Room has succesfully been added.", dto);
            return CreatedAtAction(nameof(Get), new { id = 1 }, dto);
            // return Ok();
        }
        private bool IsValid(RoomDTO dto)
        {
            if (dto == null ||
                (dto.RoomId == 0 &&
                dto.BuildingId == 0 &&
                dto.Name == null &&
                dto.RoomTypeId == 0 &&
                dto.RoomKindId == 0 &&
                dto.Capacity == 0)) 
            { return false; }
            return true;
        }
    }
}
