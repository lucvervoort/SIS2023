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
    public class EFRubricRubricRowRepository : IRubricRubricRowRepository
    {
        private readonly ILogger<EFRubricRubricRowRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, RubricRubricRow> _rubricRubricRows;

        public Dictionary<int, RubricRubricRow> RubricRubricRows
        {
            get
            {
                if (_rubricRubricRows != null)
                    return _rubricRubricRows;
                return RefreshRubricRubricRows();
            }
        }

        public EFRubricRubricRowRepository(ILogger<EFRubricRubricRowRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all RubricRubricRows up front
            RefreshRubricRubricRows();
        }

        public Dictionary<int, RubricRubricRow> RefreshRubricRubricRows()
        {
            _rubricRubricRows = new Dictionary<int, RubricRubricRow>();
            var dbRubricRubricRows = _context.RubricRubricRows.ToList();

            foreach (var rubricRubricRow in dbRubricRubricRows)
            {
                var row = new RubricRubricRow
                {
                    RubricRubricRowId = rubricRubricRow.RubricRubricRowId,
                    RubricId = rubricRubricRow.RubricId,
                    RubricRowId = rubricRubricRow.RubricRowId,
                    AutoTimeCreation = rubricRubricRow.AutoTimeCreation,
                    AutoTimeUpdate = rubricRubricRow.AutoTimeUpdate,
                    AutoUpdateCount = rubricRubricRow.AutoUpdateCount,
                    IsDeleted = rubricRubricRow.IsDeleted
                };

                _rubricRubricRows.Add(row.RubricRubricRowId, row);
            }

            return _rubricRubricRows;
        }

        public void Insert(RubricRubricRow rubricRubricRow)
        {
            if (_rubricRubricRows.ContainsKey(rubricRubricRow.RubricRubricRowId))
                return;

            var efRubricRubricRow = new EFRepository.Models.RubricRubricRow
            {
                RubricId = rubricRubricRow.RubricId,
                RubricRowId = rubricRubricRow.RubricRowId,
                AutoTimeCreation = DateTime.Now, // Set the creation time
                AutoTimeUpdate = DateTime.Now, // Set the update time
                AutoUpdateCount = 0, // Set the update count
                IsDeleted = false // Set the deletion flag
            };

            var addedRubricRubricRow = _context.RubricRubricRows.Add(efRubricRubricRow).Entity;
            var count = _context.SaveChanges();

            rubricRubricRow.RubricRubricRowId = addedRubricRubricRow.RubricRubricRowId; // Update the RubricRubricRowId with the generated ID

            _rubricRubricRows.Add(rubricRubricRow.RubricRubricRowId, rubricRubricRow);
        }

        public void Update(RubricRubricRow rubricRubricRow)
        {
            if (_rubricRubricRows.ContainsKey(rubricRubricRow.RubricRubricRowId))
            {
                // Update the corresponding EFRepository.Models.RubricRubricRow entity in the database
                var efRubricRubricRow = _context.RubricRubricRows.Find(rubricRubricRow.RubricRubricRowId);
                if (efRubricRubricRow != null)
                {
                    efRubricRubricRow.RubricId = rubricRubricRow.RubricId;
                    efRubricRubricRow.RubricRowId = rubricRubricRow.RubricRowId;
                    efRubricRubricRow.AutoTimeUpdate = DateTime.Now; // Update the update time
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(RubricRubricRow rubricRubricRow)
        {
            if (_rubricRubricRows.ContainsKey(rubricRubricRow.RubricRubricRowId))
            {
                // Delete the corresponding EFRepository.Models.RubricRubricRow entity from the database
                var efRubricRubricRow = _context.RubricRubricRows.Find(rubricRubricRow.RubricRubricRowId);
                if (efRubricRubricRow != null)
                {
                    _context.RubricRubricRows.Remove(efRubricRubricRow);
                    _context.SaveChanges();
                }
                _rubricRubricRows.Remove(rubricRubricRow.RubricRubricRowId);
            }
        }

        public bool Exists(RubricRubricRow rubricRubricRow)
        {
            return _rubricRubricRows.ContainsKey(rubricRubricRow.RubricRubricRowId);
        }
    }
}
#endif