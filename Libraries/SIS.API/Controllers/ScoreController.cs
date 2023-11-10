#if JARI
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.API.DTO;
using SIS.Domain.Interfaces;
using AutoMapper;
using SIS.Domain;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.API.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class ScoreController : ControllerBase
    {
        private readonly ILogger<ScoreController> _logger;
        private readonly IScoreRepository _repository;
        private readonly IMapper _mapper;

        public ScoreController(ILogger<ScoreController> logger, IScoreRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetScores")]
        public ActionResult<IEnumerable<ScoreDTO>> Get()
        {
            return Ok(_mapper.Map<List<ScoreDTO>>(_repository.Scores.Values.ToList()));
        }

        [HttpGet("Descriptions", Name = "GetDescriptions")]
        public ActionResult<IEnumerable<String>> GetDescriptions()
        {
            var scores = _mapper.Map<List<ScoreDTO>>(_repository.Scores.Values.ToList());
            var descriptions = scores.Select(s => s.Description);
            return Ok(descriptions);
        }

        [HttpGet("{id}", Name = "GetScore")]
        public ActionResult<ScoreDTO> Get(int id)
        {
            var score = _repository.Scores.GetValueOrDefault(id);
            if (score == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ScoreDTO>(score));
        }

        [HttpPost]
        public ActionResult<ScoreDTO> Create(ScoreDTO scoreDto)
        {
            try
            {
                if (scoreDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<Score>(scoreDto));
                return CreatedAtAction(nameof(Create), scoreDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ScoreDTO scoreDto)
        {
            if (scoreDto == null || id != scoreDto.ScoreId)
            {
                return BadRequest();
            }

            var existingScore = _repository.Scores.GetValueOrDefault(id);
            if (existingScore == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<Score>(scoreDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingScore = _repository.Scores.GetValueOrDefault(id);
            if (existingScore == null)
            {
                return NotFound();
            }

            _repository.Delete(existingScore);
            return NoContent();
        }

        [HttpPost]
        public IActionResult IsValid(ScoreDTO scoreDto)
        {
            if (scoreDto == null || (scoreDto.Total == 0 && scoreDto.Description == "string" && scoreDto.ScoreId == 0))
            {
                return BadRequest("Invalid request data.");
            }

            return Ok("Request data is valid.");
        }
    }
}
#endif