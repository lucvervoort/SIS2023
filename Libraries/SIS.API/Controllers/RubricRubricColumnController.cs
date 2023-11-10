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
    public class RubricRubricColumnController : ControllerBase
    {
        private readonly ILogger<RubricRubricColumnController> _logger;
        private readonly IRubricRubricColumnRepository _repository;
        private readonly IMapper _mapper;

        public RubricRubricColumnController(ILogger<RubricRubricColumnController> logger, IRubricRubricColumnRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRubricRubricColumns")]
        public ActionResult<IEnumerable<RubricRubricColumnDTO>> Get()
        {
            return Ok(_mapper.Map<List<RubricRubricColumnDTO>>(_repository.RubricRubricColumns.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetRubricRubricColumn")]
        public ActionResult<RubricRubricColumnDTO> Get(int id)
        {
            var rubricRubricColumn = _repository.RubricRubricColumns.GetValueOrDefault(id);
            if (rubricRubricColumn == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RubricRubricColumnDTO>(rubricRubricColumn));
        }

        [HttpPost]
        public ActionResult<RubricRubricColumnDTO> Create(RubricRubricColumnDTO rubricRubricColumnDto)
        {
            try
            {
                if (rubricRubricColumnDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<RubricRubricColumn>(rubricRubricColumnDto));
                return CreatedAtAction(nameof(Create), rubricRubricColumnDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RubricRubricColumnDTO rubricRubricColumnDto)
        {
            if (rubricRubricColumnDto == null || id != rubricRubricColumnDto.RubricRubricColumnId)
            {
                return BadRequest();
            }

            var existingRubricRubricColumn = _repository.RubricRubricColumns.GetValueOrDefault(id);
            if (existingRubricRubricColumn == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<RubricRubricColumn>(rubricRubricColumnDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRubricRubricColumn = _repository.RubricRubricColumns.GetValueOrDefault(id);
            if (existingRubricRubricColumn == null)
            {
                return NotFound();
            }

            _repository.Delete(existingRubricRubricColumn);
            return NoContent();
        }
    }
}
#endif