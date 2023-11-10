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
    public class EFPeriodRepository : IPeriodRepository
    {
        private readonly ILogger<EFPeriodRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, Period> _periods;
        public Dictionary<int, Period> Periods
        {
            get
            {
                if (_periods != null) return _periods;
                return RefreshPeriods();
            }
        }

        public EFPeriodRepository(ILogger<EFPeriodRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all periods up front
            RefreshPeriods();
        }

        public Dictionary<int, Period> RefreshPeriods()
        {
            _periods = new();
            var dbPeriods = _context.Periods.ToList();
            foreach (var period in dbPeriods)
            {
                var p = new Period
                {
                    PeriodId = period.PeriodId,
                    Name = period.Name,
                    AutoTimeCreation = period.AutoTimeCreation,
                    AutoTimeUpdate = period.AutoTimeUpdate,
                    AutoUpdateCount = period.AutoUpdateCount,
                    IsDeleted = period.IsDeleted
                };
                _periods.Add(p.PeriodId, p);
            }
            return _periods;
        }

        public void Insert(Period period)
        {
            if (_periods.ContainsKey(period.PeriodId))
                return;

            var efPeriod = new EFRepository.Models.Period
            {
                Name = period.Name,
                AutoTimeCreation = DateTime.Now, // Set the creation time
                AutoTimeUpdate = DateTime.Now, // Set the update time
                AutoUpdateCount = 0, // Set the update count
                IsDeleted = false // Set the deletion flag
            };

            var addedPeriod = _context.Periods.Add(efPeriod).Entity;
            var count = _context.SaveChanges();

            period.PeriodId = addedPeriod.PeriodId; // Update the PeriodId with the generated ID

            _periods.Add(period.PeriodId, period);
        }

        public void Update(Period period)
        {
            if (_periods.ContainsKey(period.PeriodId))
            {
                // Update the corresponding EFRepository.Models.Period entity in the database
                var efPeriod = _context.Periods.Find(period.PeriodId);
                if (efPeriod != null)
                {
                    efPeriod.Name = period.Name;
                    efPeriod.AutoTimeUpdate = DateTime.Now; // Update the update time
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(Period period)
        {
            if (_periods.ContainsKey(period.PeriodId))
            {
                // Delete the corresponding EFRepository.Models.Period entity from the database
                var efPeriod = _context.Periods.Find(period.PeriodId);
                if (efPeriod != null)
                {
                    _context.Periods.Remove(efPeriod);
                    _context.SaveChanges();
                }
                _periods.Remove(period.PeriodId);
            }
        }

        public bool Exists(Period period)
        {
            return _periods.ContainsKey(period.PeriodId);
        }
    }
}
#endif