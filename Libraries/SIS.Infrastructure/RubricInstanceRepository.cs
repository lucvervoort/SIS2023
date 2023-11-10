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
    public class EFRubricRubricColumnRepository : IRubricRubricColumnRepository
    {
        private readonly ILogger<EFRubricRubricColumnRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, RubricRubricColumn> _rubricRubricColumns;
        public Dictionary<int, RubricRubricColumn> RubricRubricColumns
        {
            get
            {
                if (_rubricRubricColumns != null) return _rubricRubricColumns;
                return RefreshRubricRubricColumns();
            }
        }

        public EFRubricRubricColumnRepository(ILogger<EFRubricRubricColumnRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all RubricRubricColumn entities up front
            RefreshRubricRubricColumns();
        }

        public Dictionary<int, RubricRubricColumn> RefreshRubricRubricColumns()
        {
            _rubricRubricColumns = new();
            var dbRubricRubricColumns = _context.RubricRubricColumns.Include(r => r.Rubric).Include(rc => rc.RubricColumn).Include(rh => rh.RubricHeader).ToList();
            foreach (var rubricRubricColumn in dbRubricRubricColumns)
            {
                var rrc = new RubricRubricColumn
                {
                    RubricRubricColumnId = rubricRubricColumn.RubricRubricColumnId,
                    RubricId = rubricRubricColumn.RubricId,
                    RubricColumnId = rubricRubricColumn.RubricColumnId,
                    RubricHeaderId = rubricRubricColumn.RubricHeaderId,
                    AutoTimeCreation = rubricRubricColumn.AutoTimeCreation,
                    AutoTimeUpdate = rubricRubricColumn.AutoTimeUpdate,
                    AutoUpdateCount = rubricRubricColumn.AutoUpdateCount,
                    IsDeleted = rubricRubricColumn.IsDeleted,
                    Rubric = new Rubric
                    {
                        RubricId = rubricRubricColumn.Rubric.RubricId,
                        Name = rubricRubricColumn.Rubric.Name, // Include relevant properties
                    },
                    RubricColumn = new RubricColumn
                    {
                        RubricColumnId = rubricRubricColumn.RubricColumn.RubricColumnId,
                        Name = rubricRubricColumn.RubricColumn.Name, // Include relevant properties
                    },
                    RubricHeader = new RubricRowHeader
                    {
                        RubricRowHeaderId = rubricRubricColumn.RubricHeader.RubricRowHeaderId,
                        Name = rubricRubricColumn.RubricHeader.Name, // Include relevant properties
                    }
                };
                _rubricRubricColumns.Add(rrc.RubricRubricColumnId, rrc);
            }
            return _rubricRubricColumns;
        }

        public void Insert(RubricRubricColumn rubricRubricColumn)
        {
            if (_rubricRubricColumns.ContainsKey(rubricRubricColumn.RubricRubricColumnId))
                return;

            var efRubricRubricColumn = new EFRepository.Models.RubricRubricColumn
            {
                RubricId = rubricRubricColumn.RubricId,
                RubricColumnId = rubricRubricColumn.RubricColumnId,
                RubricHeaderId = rubricRubricColumn.RubricHeaderId,
                AutoTimeCreation = DateTime.Now, // Set the creation time
                AutoTimeUpdate = DateTime.Now, // Set the update time
                AutoUpdateCount = 0, // Set the update count
                IsDeleted = false // Set the deletion flag
            };

            var addedRubricRubricColumn = _context.RubricRubricColumns.Add(efRubricRubricColumn).Entity;
            var count = _context.SaveChanges();

            rubricRubricColumn.RubricRubricColumnId = addedRubricRubricColumn.RubricRubricColumnId; // Update the RubricRubricColumnId with the generated ID

            _rubricRubricColumns.Add(rubricRubricColumn.RubricRubricColumnId, rubricRubricColumn);
        }

        public void Update(RubricRubricColumn rubricRubricColumn)
        {
            if (_rubricRubricColumns.ContainsKey(rubricRubricColumn.RubricRubricColumnId))
            {
                // Update the corresponding EFRepository.Models.RubricRubricColumn entity in the database
                var efRubricRubricColumn = _context.RubricRubricColumns.Find(rubricRubricColumn.RubricRubricColumnId);
                if (efRubricRubricColumn != null)
                {
                    efRubricRubricColumn.RubricId = rubricRubricColumn.RubricId;
                    efRubricRubricColumn.RubricColumnId = rubricRubricColumn.RubricColumnId;
                    efRubricRubricColumn.RubricHeaderId = rubricRubricColumn.RubricHeaderId;
                    efRubricRubricColumn.AutoTimeUpdate = DateTime.Now; // Update the update time
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(RubricRubricColumn rubricRubricColumn)
        {
            if (_rubricRubricColumns.ContainsKey(rubricRubricColumn.RubricRubricColumnId))
            {
                // Delete the corresponding EFRepository.Models.RubricRubricColumn entity from the database
                var efRubricRubricColumn = _context.RubricRubricColumns.Find(rubricRubricColumn.RubricRubricColumnId);
                if (efRubricRubricColumn != null)
                {
                    _context.RubricRubricColumns.Remove(efRubricRubricColumn);
                    _context.SaveChanges();
                }
                _rubricRubricColumns.Remove(rubricRubricColumn.RubricRubricColumnId);
            }
        }

        public bool Exists(RubricRubricColumn rubricRubricColumn)
        {
            return _rubricRubricColumns.ContainsKey(rubricRubricColumn.RubricRubricColumnId);
        }
    }
}
#endif