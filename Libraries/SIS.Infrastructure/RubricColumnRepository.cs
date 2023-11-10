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
    public class EFRubricColumnRepository : IRubricColumnRepository
    {
        private readonly ILogger<EFRubricColumnRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, RubricColumn> _rubricColumns;
        public Dictionary<int, RubricColumn> RubricColumns
        {
            get
            {
                if (_rubricColumns != null) return _rubricColumns;
                return RefreshRubricColumns();
            }
        }

        public EFRubricColumnRepository(ILogger<EFRubricColumnRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all rubric columns up front
            RefreshRubricColumns();
        }

        public Dictionary<int, RubricColumn> RefreshRubricColumns()
        {
            _rubricColumns = new Dictionary<int, RubricColumn>();
            var dbRubricColumns = _context.RubricColumns.ToList();
            foreach (var rubricColumn in dbRubricColumns)
            {
                var rc = new RubricColumn
                {
                    RubricColumnId = rubricColumn.RubricColumnId,
                    Name = rubricColumn.Name,
                    Description = rubricColumn.Description,
                    AutoTimeCreation = rubricColumn.AutoTimeCreation,
                    AutoTimeUpdate = rubricColumn.AutoTimeUpdate,
                    AutoUpdateCount = rubricColumn.AutoUpdateCount,
                    IsDeleted = rubricColumn.IsDeleted
                };
                _rubricColumns.Add(rc.RubricColumnId, rc);
            }
            return _rubricColumns;
        }

        public void Insert(RubricColumn rubricColumn)
        {
            if (_rubricColumns.ContainsKey(rubricColumn.RubricColumnId))
                return;

            var efRubricColumn = new EFRepository.Models.RubricColumn
            {
                Name = rubricColumn.Name,
                Description = rubricColumn.Description,
                AutoTimeCreation = DateTime.Now,
                AutoTimeUpdate = DateTime.Now,
                AutoUpdateCount = 0,
                IsDeleted = false
            };

            var addedRubricColumn = _context.RubricColumns.Add(efRubricColumn).Entity;
            var count = _context.SaveChanges();

            rubricColumn.RubricColumnId = addedRubricColumn.RubricColumnId;

            _rubricColumns.Add(rubricColumn.RubricColumnId, rubricColumn);
        }

        public void Update(RubricColumn rubricColumn)
        {
            if (_rubricColumns.ContainsKey(rubricColumn.RubricColumnId))
            {
                var efRubricColumn = _context.RubricColumns.Find(rubricColumn.RubricColumnId);
                if (efRubricColumn != null)
                {
                    efRubricColumn.Name = rubricColumn.Name;
                    efRubricColumn.Description = rubricColumn.Description;
                    efRubricColumn.AutoTimeUpdate = DateTime.Now;
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(RubricColumn rubricColumn)
        {
            if (_rubricColumns.ContainsKey(rubricColumn.RubricColumnId))
            {
                var efRubricColumn = _context.RubricColumns.Find(rubricColumn.RubricColumnId);
                if (efRubricColumn != null)
                {
                    _context.RubricColumns.Remove(efRubricColumn);
                    _context.SaveChanges();
                }
                _rubricColumns.Remove(rubricColumn.RubricColumnId);
            }
        }

        public bool Exists(RubricColumn rubricColumn)
        {
            return _rubricColumns.ContainsKey(rubricColumn.RubricColumnId);
        }
    }
}
#endif