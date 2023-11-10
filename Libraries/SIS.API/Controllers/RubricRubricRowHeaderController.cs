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
    public class RubricRubricRowHeaderController : ControllerBase
    {
        private readonly ILogger<RubricRubricRowHeaderController> _logger;
        private readonly IRubricRubricRowHeaderRepository _repository;
        private readonly IMapper _mapper;

        public RubricRubricRowHeaderController(ILogger<RubricRubricRowHeaderController> logger, IRubricRubricRowHeaderRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRubricRubricRowHeaders")]
        public ActionResult<IEnumerable<RubricRubricRowHeaderDTO>> Get()
        {
            return Ok(_mapper.Map<List<RubricRubricRowHeaderDTO>>(_repository.RubricRubricRowHeaders.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetRubricRubricRowHeader")]
        public ActionResult<RubricRubricRowHeaderDTO> Get(int id)
        {
            var rubricRubricRowHeader = _repository.RubricRubricRowHeaders.GetValueOrDefault(id);
            if (rubricRubricRowHeader == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RubricRubricRowHeaderDTO>(rubricRubricRowHeader));
        }

        [HttpPost]
        public ActionResult<RubricRubricRowHeaderDTO> Create(RubricRubricRowHeaderDTO rubricRubricRowHeaderDto)
        {
            try
            {
                if (rubricRubricRowHeaderDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<RubricRubricRowHeader>(rubricRubricRowHeaderDto));
                return CreatedAtAction(nameof(Create), rubricRubricRowHeaderDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RubricRubricRowHeaderDTO rubricRubricRowHeaderDto)
        {
            if (rubricRubricRowHeaderDto == null || id != rubricRubricRowHeaderDto.RubricRubricRowHeaderId)
            {
                return BadRequest();
            }

            var existingRubricRubricRowHeader = _repository.RubricRubricRowHeaders.GetValueOrDefault(id);
            if (existingRubricRubricRowHeader == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<RubricRubricRowHeader>(rubricRubricRowHeaderDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRubricRubricRowHeader = _repository.RubricRubricRowHeaders.GetValueOrDefault(id);
            if (existingRubricRubricRowHeader == null)
            {
                return NotFound();
            }

            _repository.Delete(existingRubricRubricRowHeader);
            return NoContent();
        }
    }
}
#endif