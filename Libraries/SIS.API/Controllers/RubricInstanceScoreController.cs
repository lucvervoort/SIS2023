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
    public class RubricInstanceScoreController : ControllerBase
    {
        private readonly ILogger<RubricInstanceScoreController> _logger;
        private readonly IRubricInstanceScoreRepository _repository;
        private readonly IMapper _mapper;

        public RubricInstanceScoreController(ILogger<RubricInstanceScoreController> logger, IRubricInstanceScoreRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRubricInstanceScores")]
        public ActionResult<IEnumerable<RubricInstanceScoreDTO>> Get()
        {
            return Ok(_mapper.Map<List<RubricInstanceScoreDTO>>(_repository.RubricInstanceScores.Values.ToList()));
        }

        [HttpGet("{id}", Name = "GetRubricInstanceScore")]
        public ActionResult<RubricInstanceScoreDTO> Get(int id)
        {
            var rubricInstanceScore = _repository.RubricInstanceScores.GetValueOrDefault(id);
            if (rubricInstanceScore == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RubricInstanceScoreDTO>(rubricInstanceScore));
        }

        [HttpPost]
        public ActionResult<RubricInstanceScoreDTO> Create(RubricInstanceScoreDTO rubricInstanceScoreDto)
        {
            try
            {
                if (rubricInstanceScoreDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<RubricInstanceScore>(rubricInstanceScoreDto));
                return CreatedAtAction(nameof(Create), rubricInstanceScoreDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RubricInstanceScoreDTO rubricInstanceScoreDto)
        {
            if (rubricInstanceScoreDto == null || id != rubricInstanceScoreDto.RubricInstanceScoreId)
            {
                return BadRequest();
            }

            var existingRubricInstanceScore = _repository.RubricInstanceScores.GetValueOrDefault(id);
            if (existingRubricInstanceScore == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<RubricInstanceScore>(rubricInstanceScoreDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingRubricInstanceScore = _repository.RubricInstanceScores.GetValueOrDefault(id);
            if (existingRubricInstanceScore == null)
            {
                return NotFound();
            }

            _repository.Delete(existingRubricInstanceScore);
            return NoContent();
        }
    }
}
#endif