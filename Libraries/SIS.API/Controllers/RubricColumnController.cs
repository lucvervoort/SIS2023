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
    public class RubricColumnController : ControllerBase
    {
        private readonly ILogger<RubricColumnController> _logger;
        private readonly IRubricColumnRepository _repository;
        private readonly IMapper _mapper;

        public RubricColumnController(ILogger<RubricColumnController> logger, IRubricColumnRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRubricColumns")]
        public ActionResult<IEnumerable<RubricColumnDTO>> Get()
        {
            return Ok(_mapper.Map<List<RubricColumnDTO>>(_repository.RubricColumns.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetRubricColumn")]
        public ActionResult<RubricColumnDTO> Get(int id)
        {
            var rubricColumn = _repository.RubricColumns.GetValueOrDefault(id);
            if (rubricColumn == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RubricColumnDTO>(rubricColumn));
        }

        [HttpPost]
        public ActionResult<RubricColumnDTO> Create(RubricColumnDTO rubricColumnDto)
        {
            try
            {
                if (rubricColumnDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<RubricColumn>(rubricColumnDto));
                return CreatedAtAction(nameof(Create), rubricColumnDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RubricColumnDTO rubricColumnDto)
        {
            if (rubricColumnDto == null || id != rubricColumnDto.RubricColumnId)
            {
                return BadRequest();
            }

            var existingRubricColumn = _repository.RubricColumns.GetValueOrDefault(id);
            if (existingRubricColumn == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<RubricColumn>(rubricColumnDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRubricColumn = _repository.RubricColumns.GetValueOrDefault(id);
            if (existingRubricColumn == null)
            {
                return NotFound();
            }

            _repository.Delete(existingRubricColumn);
            return NoContent();
        }
    }
}
#endif