#if JARI
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using SIS.Domain.Interfaces;
using AutoMapper;
using SIS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresenceController : ControllerBase
    {
        private readonly ILogger<PresenceController> _logger;
        private readonly IPresenceRepository _repository;
        private readonly IMapper _mapper;

        public PresenceController(ILogger<PresenceController> logger, IPresenceRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPresences")]
        public ActionResult<IEnumerable<PresenceDTO>> Get()
        {
            return Ok(_mapper.Map<List<PresenceDTO>>(_repository.Presences.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetPresence")]
        public ActionResult<PresenceDTO> Get(int id)
        {
            var presence = _repository.Presences.GetValueOrDefault(id);
            if (presence == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PresenceDTO>(presence));
        }

        [HttpPost]
        public ActionResult<PresenceDTO> Create(PresenceDTO presenceDto)
        {
            try
            {
                if (presenceDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<Presence>(presenceDto));
                return CreatedAtAction(nameof(Create), presenceDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PresenceDTO presenceDto)
        {
            if (presenceDto == null || id != presenceDto.PresenceId)
            {
                return BadRequest();
            }

            var existingPresence = _repository.Presences.GetValueOrDefault(id);
            if (existingPresence == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<Presence>(presenceDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPresence = _repository.Presences.GetValueOrDefault(id);
            if (existingPresence == null)
            {
                return NotFound();
            }

            _repository.Delete(existingPresence);
            return NoContent();
        }
    }
}
#endif