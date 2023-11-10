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
    [Route("[controller]")]
    public class PeriodController : ControllerBase
    {
        private readonly ILogger<PeriodController> _logger;
        private readonly ISISPeriodRepository _repository;
        private readonly IMapper _mapper;

        public PeriodController(ILogger<PeriodController> logger, ISISPeriodRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetPeriods")]
        public ActionResult<IEnumerable<PeriodDTO>> Get()
        {
            return Ok(_mapper.Map<List<PeriodDTO>>(_repository.Periods));
        }

#if JARI
        [HttpGet("Descriptions", Name = "GetDescriptions")]
        public ActionResult<IEnumerable<String>> GetDescriptions()
        {
            var periods = _mapper.Map<List<PeriodDTO>>(_repository.Periods);
            var descriptions = periods.Select(p => p.Description);
            return Ok(descriptions);
        }
#endif

        [HttpGet("{id}", Name = "GetPeriod")]
        public ActionResult<PeriodDTO> Get(int id)
        {
            var period = _repository.Periods.GetValueOrDefault(id);
            if (period == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PeriodDTO>(period));
        }

        [HttpPost]
        public ActionResult<PeriodDTO> Create(PeriodDTO periodDto)
        {
            try
            {
                if (periodDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<Period>(periodDto));
                return CreatedAtAction(nameof(Create), periodDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PeriodDTO periodDto)
        {
            if (periodDto == null || id != periodDto.PeriodId)
            {
                return BadRequest();
            }

            var existingPeriod = _repository.Periods.GetValueOrDefault(id);
            if (existingPeriod == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<Period>(periodDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPeriod = _repository.Periods.GetValueOrDefault(id);
            if (existingPeriod == null)
            {
                return NotFound();
            }

            _repository.Delete(existingPeriod);
            return NoContent();
        }

        [HttpPost]
        public IActionResult IsValid(PeriodDTO periodDto)
        {
            if (periodDto == null || (periodDto.Name == "string" && periodDto.PeriodId == 0))
            {
                return BadRequest("Invalid request data.");
            }

            return Ok("Request data is valid.");
        }
    }
}
#endif