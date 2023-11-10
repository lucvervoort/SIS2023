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
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public TestController(ILogger<TestController> logger, ITestRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetTests")]
        public ActionResult<IEnumerable<TestDTO>> Get()
        {
            return Ok(_mapper.Map<List<TestDTO>>(_repository.Tests.Values.ToList()));
        }

        [HttpGet("Descriptions", Name = "GetDescriptions")]
        public ActionResult<IEnumerable<String>> GetDescriptions()
        {
            var tests = _mapper.Map<List<TestDTO>>(_repository.Tests.Values.ToList());
            var descriptions = tests.Select(t => t.Description);
            return Ok(descriptions);
        }

        [HttpGet("{id}", Name = "GetTest")]
        public ActionResult<TestDTO> Get(int id)
        {
            var test = _repository.Tests.GetValueOrDefault(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TestDTO>(test));
        }

        [HttpPost]
        public ActionResult<TestDTO> Create(TestDTO testDto)
        {
            try
            {
                if (testDto == null)
                {
                    return BadRequest();
                }
                _repository.Insert(_mapper.Map<Test>(testDto));
                return CreatedAtAction(nameof(Create), testDto);
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TestDTO testDto)
        {
            if (testDto == null || id != testDto.TestId)
            {
                return BadRequest();
            }

            var existingTest = _repository.Tests.GetValueOrDefault(id);
            if (existingTest == null)
            {
                return NotFound();
            }

            _repository.Update(_mapper.Map<Test>(testDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingTest = _repository.Tests.GetValueOrDefault(id);
            if (existingTest == null)
            {
                return NotFound();
            }

            _repository.Delete(existingTest);
            return NoContent();
        }

        [HttpPost]
        public IActionResult IsValid(TestDTO testDto)
        {
            if (testDto == null || (testDto.OfficialCode == 0 && testDto.TestId == 0))
            {
                return BadRequest("Invalid request data.");
            }

            return Ok("Request data is valid.");
        }
    }
}
#endif