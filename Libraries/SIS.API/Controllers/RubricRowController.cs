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
    public class RubricRowController : ControllerBase
    {
        private readonly ILogger<RubricRowController> _logger;
        private readonly IRubricRowRepository _repository;
        private readonly IMapper _mapper;

        public RubricRowController(ILogger<RubricRowController> logger, IRubricRowRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRubricRows")]
        public ActionResult<IEnumerable<RubricRowDTO>> Get()
        {
            return Ok(_mapper.Map<List<RubricRowDTO>>(_repository.RubricRows.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetRubricRow")]
        public ActionResult<RubricRowDTO> Get(int id)
        {
            var rubricRow = _repository.RubricRows.GetValueOrDefault(id);
            if (rubricRow == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RubricRowDTO>(rubricRow));
        }

        [HttpPost]
        public ActionResult<RubricRowDTO> Create(RubricRowDTO rubricRowDto)
        {
            try
            {
                if (rubricRowDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<RubricRow>(rubricRowDto));
                return CreatedAtAction(nameof(Create), rubricRowDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RubricRowDTO rubricRowDto)
        {
            if (rubricRowDto == null || id != rubricRowDto.RubricRowId)
            {
                return BadRequest();
            }

            var existingRubricRow = _repository.RubricRows.GetValueOrDefault(id);
            if (existingRubricRow == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<RubricRow>(rubricRowDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRubricRow = _repository.RubricRows.GetValueOrDefault(id);
            if (existingRubricRow == null)
            {
                return NotFound();
            }

            _repository.Delete(existingRubricRow);
            return NoContent();
        }
    }
}
#endif