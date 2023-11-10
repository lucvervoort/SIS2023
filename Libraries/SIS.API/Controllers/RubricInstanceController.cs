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
    public class RubricInstanceController : ControllerBase
    {
        private readonly ILogger<RubricInstanceController> _logger;
        private readonly IRubricInstanceRepository _repository;
        private readonly IMapper _mapper;

        public RubricInstanceController(ILogger<RubricInstanceController> logger, IRubricInstanceRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRubricInstances")]
        public ActionResult<IEnumerable<RubricInstanceDTO>> Get()
        {
            return Ok(_mapper.Map<List<RubricInstanceDTO>>(_repository.RubricInstances.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetRubricInstance")]
        public ActionResult<RubricInstanceDTO> Get(int id)
        {
            var rubricInstance = _repository.RubricInstances.GetValueOrDefault(id);
            if (rubricInstance == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RubricInstanceDTO>(rubricInstance));
        }

        [HttpPost]
        public ActionResult<RubricInstanceDTO> Create(RubricInstanceDTO rubricInstanceDto)
        {
            try
            {
                if (rubricInstanceDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<RubricInstance>(rubricInstanceDto));
                return CreatedAtAction(nameof(Create), rubricInstanceDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RubricInstanceDTO rubricInstanceDto)
        {
            if (rubricInstanceDto == null || id != rubricInstanceDto.RubricInstanceId)
            {
                return BadRequest();
            }

            var existingRubricInstance = _repository.RubricInstances.GetValueOrDefault(id);
            if (existingRubricInstance == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<RubricInstance>(rubricInstanceDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRubricInstance = _repository.RubricInstances.GetValueOrDefault(id);
            if (existingRubricInstance == null)
            {
                return NotFound();
            }

            _repository.Delete(existingRubricInstance);
            return NoContent();
        }
    }
}
#endif