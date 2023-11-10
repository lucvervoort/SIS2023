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
    public class RubricRubricRowController : ControllerBase
    {
        private readonly ILogger<RubricRubricRowController> _logger;
        private readonly IRubricRubricRowRepository _repository;
        private readonly IMapper _mapper;

        public RubricRubricRowController(ILogger<RubricRubricRowController> logger, IRubricRubricRowRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRubricRubricRows")]
        public ActionResult<IEnumerable<RubricRubricRowDTO>> Get()
        {
            return Ok(_mapper.Map<List<RubricRubricRowDTO>>(_repository.RubricRubricRows.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetRubricRubricRow")]
        public ActionResult<RubricRubricRowDTO> Get(int id)
        {
            var rubricRubricRow = _repository.RubricRubricRows.GetValueOrDefault(id);
            if (rubricRubricRow == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RubricRubricRowDTO>(rubricRubricRow));
        }

        [HttpPost]
        public ActionResult<RubricRubricRowDTO> Create(RubricRubricRowDTO rubricRubricRowDto)
        {
            try
            {
                if (rubricRubricRowDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<RubricRubricRow>(rubricRubricRowDto));
                return CreatedAtAction(nameof(Create), rubricRubricRowDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RubricRubricRowDTO rubricRubricRowDto)
        {
            if (rubricRubricRowDto == null || id != rubricRubricRowDto.RubricRubricRowId)
            {
                return BadRequest();
            }

            var existingRubricRubricRow = _repository.RubricRubricRows.GetValueOrDefault(id);
            if (existingRubricRubricRow == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<RubricRubricRow>(rubricRubricRowDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRubricRubricRow = _repository.RubricRubricRows.GetValueOrDefault(id);
            if (existingRubricRubricRow == null)
            {
                return NotFound();
            }

            _repository.Delete(existingRubricRubricRow);
            return NoContent();
        }
    }
}
#endif