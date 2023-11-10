#if JARI
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using AutoMapper;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresenceStateController : ControllerBase
    {
        private readonly ILogger<PresenceStateController> _logger;
        private readonly IPresenceStateRepository _repository;
        private readonly IMapper _mapper;

        public PresenceStateController(ILogger<PresenceStateController> logger, IPresenceStateRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPresenceStates")]
        public ActionResult<IEnumerable<PresenceStateDTO>> Get()
        {
            return Ok(_mapper.Map<List<PresenceStateDTO>>(_repository.PresenceStates.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetPresenceState")]
        public ActionResult<PresenceStateDTO> Get(int id)
        {
            var presenceState = _repository.PresenceStates.GetValueOrDefault(id);
            if (presenceState == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PresenceStateDTO>(presenceState));
        }

        [HttpPost]
        public ActionResult<PresenceStateDTO> Create(PresenceStateDTO presenceStateDto)
        {
            try
            {
                if (presenceStateDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<PresenceState>(presenceStateDto));
                return CreatedAtAction(nameof(Create), presenceStateDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PresenceStateDTO presenceStateDto)
        {
            if (presenceStateDto == null || id != presenceStateDto.PresenceStateId)
            {
                return BadRequest();
            }

            var existingPresenceState = _repository.PresenceStates.GetValueOrDefault(id);
            if (existingPresenceState == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<PresenceState>(presenceStateDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPresenceState = _repository.PresenceStates.GetValueOrDefault(id);
            if (existingPresenceState == null)
            {
                return NotFound();
            }

            _repository.Delete(existingPresenceState);
            return NoContent();
        }
    }
}
#endif