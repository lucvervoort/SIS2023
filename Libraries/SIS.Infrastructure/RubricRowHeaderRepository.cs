#if JARI
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.Infrastructure
{
    public class EFRubricRowHeaderRepository : IRubricRowHeaderRepository
    {
        private readonly ILogger<EFRubricRowHeaderRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, RubricRowHeader> _rubricRowHeaders;

        public Dictionary<int, RubricRowHeader> RubricRowHeaders
        {
            get
            {
                if (_rubricRowHeaders != null) return _rubricRowHeaders;
                return RefreshRubricRowHeaders();
            }
        }

        public EFRubricRowHeaderRepository(ILogger<EFRubricRowHeaderRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all RubricRowHeaders up front
            RefreshRubricRowHeaders();
        }

        public Dictionary<int, RubricRowHeader> RefreshRubricRowHeaders()
        {
            _rubricRowHeaders = new Dictionary<int, RubricRowHeader>();
            var dbRubricRowHeaders = _context.RubricRowHeaders.ToList();
            foreach (var rubricRowHeader in dbRubricRowHeaders)
            {
                var rrh = new RubricRowHeader
                {
                    RubricRowHeaderId = rubricRowHeader.RubricRowHeaderId,
                    Name = rubricRowHeader.Name,
                    Description = rubricRowHeader.Description,
                    RubricRowHeaderParentId = rubricRowHeader.RubricRowHeaderParentId,
                    AutoTimeCreation = rubricRowHeader.AutoTimeCreation,
                    AutoTimeUpdate = rubricRowHeader.AutoTimeUpdate,
                    AutoUpdateCount = rubricRowHeader.AutoUpdateCount,
                    IsDeleted = rubricRowHeader.IsDeleted
                };
                _rubricRowHeaders.Add(rrh.RubricRowHeaderId, rrh);
            }
            return _rubricRowHeaders;
        }

        public void Insert(RubricRowHeader rubricRowHeader)
        {
            if (_rubricRowHeaders.ContainsKey(rubricRowHeader.RubricRowHeaderId))
                return;

            var efRubricRowHeader = new EFRepository.Models.RubricRowHeader
            {
                Name = rubricRowHeader.Name,
                Description = rubricRowHeader.Description,
                RubricRowHeaderParentId = rubricRowHeader.RubricRowHeaderParentId,
                AutoTimeCreation = DateTime.Now,
                AutoTimeUpdate = DateTime.Now,
                AutoUpdateCount = 0,
                IsDeleted = false
            };

            var addedRubricRowHeader = _context.RubricRowHeaders.Add(efRubricRowHeader).Entity;
            var count = _context.SaveChanges();

            rubricRowHeader.RubricRowHeaderId = addedRubricRowHeader.RubricRowHeaderId;

            _rubricRowHeaders.Add(rubricRowHeader.RubricRowHeaderId, rubricRowHeader);
        }

        public void Update(RubricRowHeader rubricRowHeader)
        {
            if (_rubricRowHeaders.ContainsKey(rubricRowHeader.RubricRowHeaderId))
            {
                var efRubricRowHeader = _context.RubricRowHeaders.Find(rubricRowHeader.RubricRowHeaderId);
                if (efRubricRowHeader != null)
                {
                    efRubricRowHeader.Name = rubricRowHeader.Name;
                    efRubricRowHeader.Description = rubricRowHeader.Description;
                    efRubricRowHeader.RubricRowHeaderParentId = rubricRowHeader.RubricRowHeaderParentId;
                    efRubricRowHeader.AutoTimeUpdate = DateTime.Now;
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(RubricRowHeader rubricRowHeader)
        {
            if (_rubricRowHeaders.ContainsKey(rubricRowHeader.RubricRowHeaderId))
            {
                var efRubricRowHeader = _context.RubricRowHeaders.Find(rubricRowHeader.RubricRowHeaderId);
                if (efRubricRowHeader != null)
                {
                    _context.RubricRowHeaders.Remove(efRubricRowHeader);
                    _context.SaveChanges();
                }
                _rubricRowHeaders.Remove(rubricRowHeader.RubricRowHeaderId);
            }
        }

        public bool Exists(RubricRowHeader rubricRowHeader)
        {
            return _rubricRowHeaders.ContainsKey(rubricRowHeader.RubricRowHeaderId);
        }
    }
}
#endif