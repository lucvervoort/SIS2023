#if JARI
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;
using System.Linq;

namespace SIS.Infrastructure
{
    public class EFRubricRepository : IRubricRepository
    {
        private readonly ILogger<EFRubricRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, Rubric> _rubrics;

        public Dictionary<int, Rubric> Rubrics
        {
            get
            {
                if (_rubrics != null) return _rubrics;
                return RefreshRubrics();
            }
        }

        public EFRubricRepository(ILogger<EFRubricRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all Rubrics up front
            RefreshRubrics();
        }

        public Dictionary<int, Rubric> RefreshRubrics()
        {
            _rubrics = new Dictionary<int, Rubric>();
            var dbRubrics = _context.Rubrics.ToList();
            foreach (var rubric in dbRubrics)
            {
                var r = new Rubric
                {
                    RubricId = rubric.RubricId,
                    Name = rubric.Name,
                    Description = rubric.Description,
                    MaxScore = rubric.MaxScore,
                    // Set other properties as needed
                };
                _rubrics.Add(r.RubricId, r);
            }
            return _rubrics;
        }

        public void Insert(Rubric rubric)
        {
            if (_rubrics.ContainsKey(rubric.RubricId))
                return;

            var efRubric = new EFRepository.Models.Rubric
            {
                // Map Rubric properties to EFRepository.Models.Rubric
            };

            var addedRubric = _context.Rubrics.Add(efRubric).Entity;
            var count = _context.SaveChanges();

            rubric.RubricId = addedRubric.RubricId;

            _rubrics.Add(rubric.RubricId, rubric);
        }

        public void Update(Rubric rubric)
        {
            if (_rubrics.ContainsKey(rubric.RubricId))
            {
                // Update the corresponding EFRepository.Models.Rubric entity in the database
                var efRubric = _context.Rubrics.Find(rubric.RubricId);
                if (efRubric != null)
                {
                    // Map updated properties from Rubric to EFRepository.Models.Rubric
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(Rubric rubric)
        {
            if (_rubrics.ContainsKey(rubric.RubricId))
            {
                // Delete the corresponding EFRepository.Models.Rubric entity from the database
                var efRubric = _context.Rubrics.Find(rubric.RubricId);
                if (efRubric != null)
                {
                    _context.Rubrics.Remove(efRubric);
                    _context.SaveChanges();
                }
                _rubrics.Remove(rubric.RubricId);
            }
        }

        public bool Exists(Rubric rubric)
        {
            return _rubrics.ContainsKey(rubric.RubricId);
        }
    }
}
#endif