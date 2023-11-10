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
    public class EFRubricRubricRowHeaderRepository : IRubricRubricRowHeaderRepository
    {
        private readonly ILogger<EFRubricRubricRowHeaderRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, RubricRubricRowHeader> _rubricRubricRowHeaders;

        public Dictionary<int, RubricRubricRowHeader> RubricRubricRowHeaders
        {
            get
            {
                if (_rubricRubricRowHeaders != null) return _rubricRubricRowHeaders;
                return RefreshRubricRubricRowHeaders();
            }
        }

        public EFRubricRubricRowHeaderRepository(ILogger<EFRubricRubricRowHeaderRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all RubricRubricRowHeaders up front
            RefreshRubricRubricRowHeaders();
        }

        public Dictionary<int, RubricRubricRowHeader> RefreshRubricRubricRowHeaders()
        {
            _rubricRubricRowHeaders = new Dictionary<int, RubricRubricRowHeader>();
            var dbRubricRubricRowHeaders = _context.RubricRubricRowHeaders.ToList();
            foreach (var rubricRubricRowHeader in dbRubricRubricRowHeaders)
            {
                var r = new RubricRubricRowHeader
                {
                    RubricRubricRowHeaderId = rubricRubricRowHeader.RubricRubricRowHeaderId,
                    // Set other properties as needed
                };
                _rubricRubricRowHeaders.Add(r.RubricRubricRowHeaderId, r);
            }
            return _rubricRubricRowHeaders;
        }

        public void Insert(RubricRubricRowHeader rubricRubricRowHeader)
        {
            if (_rubricRubricRowHeaders.ContainsKey(rubricRubricRowHeader.RubricRubricRowHeaderId))
                return;

            var efRubricRubricRowHeader = new EFRepository.Models.RubricRubricRowHeader
            {
                // Map RubricRubricRowHeader properties to EFRepository.Models.RubricRubricRowHeader
            };

            var addedRubricRubricRowHeader = _context.RubricRubricRowHeaders.Add(efRubricRubricRowHeader).Entity;
            var count = _context.SaveChanges();

            rubricRubricRowHeader.RubricRubricRowHeaderId = addedRubricRubricRowHeader.RubricRubricRowHeaderId;

            _rubricRubricRowHeaders.Add(rubricRubricRowHeader.RubricRubricRowHeaderId, rubricRubricRowHeader);
        }

        public void Update(RubricRubricRowHeader rubricRubricRowHeader)
        {
            if (_rubricRubricRowHeaders.ContainsKey(rubricRubricRowHeader.RubricRubricRowHeaderId))
            {
                // Update the corresponding EFRepository.Models.RubricRubricRowHeader entity in the database
                var efRubricRubricRowHeader = _context.RubricRubricRowHeaders.Find(rubricRubricRowHeader.RubricRubricRowHeaderId);
                if (efRubricRubricRowHeader != null)
                {
                    // Map updated properties from RubricRubricRowHeader to EFRepository.Models.RubricRubricRowHeader
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(RubricRubricRowHeader rubricRubricRowHeader)
        {
            if (_rubricRubricRowHeaders.ContainsKey(rubricRubricRowHeader.RubricRubricRowHeaderId))
            {
                // Delete the corresponding EFRepository.Models.RubricRubricRowHeader entity from the database
                var efRubricRubricRowHeader = _context.RubricRubricRowHeaders.Find(rubricRubricRowHeader.RubricRubricRowHeaderId);
                if (efRubricRubricRowHeader != null)
                {
                    _context.RubricRubricRowHeaders.Remove(efRubricRubricRowHeader);
                    _context.SaveChanges();
                }
                _rubricRubricRowHeaders.Remove(rubricRubricRowHeader.RubricRubricRowHeaderId);
            }
        }

        public bool Exists(RubricRubricRowHeader rubricRubricRowHeader)
        {
            return _rubricRubricRowHeaders.ContainsKey(rubricRubricRowHeader.RubricRubricRowHeaderId);
        }
    }
}
#endif