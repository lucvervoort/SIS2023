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
    public class RubricController : ControllerBase
    {
        private readonly ILogger<RubricController> _logger;
        private readonly IRubricRepository _repository;
        private readonly IMapper _mapper;

        public RubricController(ILogger<RubricController> logger, IRubricRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRubrics")]
        public ActionResult<IEnumerable<RubricDTO>> Get()
        {
            return Ok(_mapper.Map<List<RubricDTO>>(_repository.Rubrics.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetRubric")]
        public ActionResult<RubricDTO> Get(int id)
        {
            var rubric = _repository.Rubrics.GetValueOrDefault(id);
            if (rubric == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RubricDTO>(rubric));
        }

        [HttpPost]
        public ActionResult<RubricDTO> Create(RubricDTO rubricDto)
        {
            try
            {
                if (rubricDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<Rubric>(rubricDto));
                return CreatedAtAction(nameof(Create), rubricDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RubricDTO rubricDto)
        {
            if (rubricDto == null || id != rubricDto.RubricId)
            {
                return BadRequest();
            }

            var existingRubric = _repository.Rubrics.GetValueOrDefault(id);
            if (existingRubric == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<Rubric>(rubricDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRubric = _repository.Rubrics.GetValueOrDefault(id);
            if (existingRubric == null)
            {
                return NotFound();
            }

            _repository.Delete(existingRubric);
            return NoContent();
        }
    }
}
#endif