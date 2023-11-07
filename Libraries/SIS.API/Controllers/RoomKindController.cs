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
    public class RoomKindController : ControllerBase
    {
        private readonly ILogger<RoomKindController> _logger;
        private readonly ISISRoomKindRepository _repository;
        private readonly IMapper _mapper;

        public RoomKindController(ILogger<RoomKindController> logger, ISISRoomKindRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomKindDTO>> Get()
        {
            return Ok(_mapper.Map<List<RoomKindDTO>>(_repository.RoomKinds.Values.ToList()));
        }

        [HttpGet("RoomKindName", Name = "RoomKindName")]
        public ActionResult<IEnumerable<String>> GetName()
        {
            var roomKinds = _mapper.Map<List<RoomKindDTO>>(_repository.RoomKinds.Values.ToList());
            var name = roomKinds.Select(rmk => rmk.Name);
            return Ok(name);
        }

        [HttpDelete(Name = "DeleteRoomKind")]
        public ActionResult Delete(int id)
        {
            var roomKindToDelete = _repository.RoomKinds.Values.FirstOrDefault(rmk => rmk.RoomKindId == id);
            if (roomKindToDelete == null)
            {
                return NotFound();
            }

            _repository.Delete(roomKindToDelete);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Put([Required] int id, [FromBody][Required] RoomKindDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var roomKindToUpdate = _repository.RoomKinds.Values.FirstOrDefault(rm => rm.RoomKindId == id);

            //UPDATE
            _repository.Update(roomKindToUpdate, _mapper.Map<RoomKind>(dto));
            return Ok("RoomKind has succesfully been updated."); ;
        }



        [HttpPost]
        public IActionResult Post([FromBody][Required] RoomKindDTO dto)
        {
            //If DTO comes back with default values or is null
            if (!IsValid(dto))
            {
                return BadRequest("Invalid request data.");
            }

            var RoomKindToCreate = _mapper.Map<RoomKind>(dto);

            //INSERT
            _repository.Insert(_mapper.Map<RoomKind>(dto));
            //return CreatedAtAction("New RoomKind has succesfully been added.", dto);
            return CreatedAtAction(nameof(Get), new { id = 1 }, dto);
            // return Ok();
        }


        private bool IsValid(RoomKindDTO dto)
        {
            if (dto == null || (dto.RoomKindId == 0 && dto.Name == null ))
            { return false; }
            return true;
        }
    }
}
