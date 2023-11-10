#if JARI
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;
using System.Collections.Generic;
using System.Linq;

namespace SIS.Infrastructure
{
    public class EFRubricRowRepository : IRubricRowRepository
    {
        private readonly ILogger<EFRubricRowRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, RubricRow> _rubricRows;
        public Dictionary<int, RubricRow> RubricRows
        {
            get
            {
                if (_rubricRows != null) return _rubricRows;
                return RefreshRubricRows();
            }
        }

        public EFRubricRowRepository(ILogger<EFRubricRowRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all rubric rows up front
            RefreshRubricRows();
        }

        public Dictionary<int, RubricRow> RefreshRubricRows()
        {
            _rubricRows = new Dictionary<int, RubricRow>();
            var dbRubricRows = _context.RubricRows.ToList();
            foreach (var rubricRow in dbRubricRows)
            {
                var rr = new RubricRow
                {
                    RubricRowId = rubricRow.RubricRowId,
                    Name = rubricRow.Name,
                    Description = rubricRow.Description,
                    MaxScore = rubricRow.MaxScore,
                    AutoTimeCreation = rubricRow.AutoTimeCreation,
                    AutoTimeUpdate = rubricRow.AutoTimeUpdate,
                    AutoUpdateCount = rubricRow.AutoUpdateCount,
                    IsDeleted = rubricRow.IsDeleted
                };
                _rubricRows.Add(rr.RubricRowId, rr);
            }
            return _rubricRows;
        }

        public void Insert(RubricRow rubricRow)
        {
            if (_rubricRows.ContainsKey(rubricRow.RubricRowId))
                return;

            var efRubricRow = new EFRepository.Models.RubricRow
            {
                Name = rubricRow.Name,
                Description = rubricRow.Description,
                MaxScore = rubricRow.MaxScore,
                AutoTimeCreation = DateTime.Now,
                AutoTimeUpdate = DateTime.Now,
                AutoUpdateCount = 0,
                IsDeleted = false
            };

            var addedRubricRow = _context.RubricRows.Add(efRubricRow).Entity;
            var count = _context.SaveChanges();

            rubricRow.RubricRowId = addedRubricRow.RubricRowId;

            _rubricRows.Add(rubricRow.RubricRowId, rubricRow);
        }

        public void Update(RubricRow rubricRow)
        {
            if (_rubricRows.ContainsKey(rubricRow.RubricRowId))
            {
                var efRubricRow = _context.RubricRows.Find(rubricRow.RubricRowId);
                if (efRubricRow != null)
                {
                    efRubricRow.Name = rubricRow.Name;
                    efRubricRow.Description = rubricRow.Description;
                    efRubricRow.MaxScore = rubricRow.MaxScore;
                    efRubricRow.AutoTimeUpdate = DateTime.Now;
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(RubricRow rubricRow)
        {
            if (_rubricRows.ContainsKey(rubricRow.RubricRowId))
            {
                var efRubricRow = _context.RubricRows.Find(rubricRow.RubricRowId);
                if (efRubricRow != null)
                {
                    _context.RubricRows.Remove(efRubricRow);
                    _context.SaveChanges();
                }
                _rubricRows.Remove(rubricRow.RubricRowId);
            }
        }

        public bool Exists(RubricRow rubricRow)
        {
            return _rubricRows.ContainsKey(rubricRow.RubricRowId);
        }
    }
}
#endif