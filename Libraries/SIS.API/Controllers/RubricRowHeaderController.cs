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
    public class RubricRowHeaderController : ControllerBase
    {
        private readonly ILogger<RubricRowHeaderController> _logger;
        private readonly IRubricRowHeaderRepository _repository;
        private readonly IMapper _mapper;

        public RubricRowHeaderController(ILogger<RubricRowHeaderController> logger, IRubricRowHeaderRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRubricRowHeaders")]
        public ActionResult<IEnumerable<RubricRowHeaderDTO>> Get()
        {
            return Ok(_mapper.Map<List<RubricRowHeaderDTO>>(_repository.RubricRowHeaders.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetRubricRowHeader")]
        public ActionResult<RubricRowHeaderDTO> Get(int id)
        {
            var rubricRowHeader = _repository.RubricRowHeaders.GetValueOrDefault(id);
            if (rubricRowHeader == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RubricRowHeaderDTO>(rubricRowHeader));
        }

        [HttpPost]
        public ActionResult<RubricRowHeaderDTO> Create(RubricRowHeaderDTO rubricRowHeaderDto)
        {
            try
            {
                if (rubricRowHeaderDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<RubricRowHeader>(rubricRowHeaderDto));
                return CreatedAtAction(nameof(Create), rubricRowHeaderDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RubricRowHeaderDTO rubricRowHeaderDto)
        {
            if (rubricRowHeaderDto == null || id != rubricRowHeaderDto.RubricRowHeaderId)
            {
                return BadRequest();
            }

            var existingRubricRowHeader = _repository.RubricRowHeaders.GetValueOrDefault(id);
            if (existingRubricRowHeader == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<RubricRowHeader>(rubricRowHeaderDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRubricRowHeader = _repository.RubricRowHeaders.GetValueOrDefault(id);
            if (existingRubricRowHeader == null)
            {
                return NotFound();
            }

            _repository.Delete(existingRubricRowHeader);
            return NoContent();
        }
    }
}
#endif