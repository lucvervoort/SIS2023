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
    public class EFTestRepository : ITestRepository
    {
        private readonly ILogger<EFTestRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, Test> _tests;
        public Dictionary<int, Test> Tests
        {
            get
            {
                if (_tests != null) return _tests;
                return RefreshTests();
            }
        }

        public EFTestRepository(ILogger<EFTestRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all tests up front
            RefreshTests();
        }

        public Dictionary<int, Test> RefreshTests()
        {
            _tests = new();
            var dbTests = _context.Tests.Include(t => t.Scores).ToList();
            foreach (var test in dbTests)
            {
                var t = new Test
                {
                    TestId = test.TestId,
                    OfficialCode = test.OfficialCode,
                    CourseId = test.CourseId,
                    AutoTimeCreation = test.AutoTimeCreation,
                    AutoTimeUpdate = test.AutoTimeUpdate,
                    AutoUpdateCount = test.AutoUpdateCount,
                    IsDeleted = test.IsDeleted,
                };
                _tests.Add(t.TestId, t);
            }
            return _tests;
        }

        public void Insert(Test test)
        {
            if (_tests.ContainsKey(test.TestId))
                return;

            var efTest = new EFRepository.Models.Test
            {
                OfficialCode = test.OfficialCode,
                CourseId = test.CourseId,
                AutoTimeCreation = DateTime.Now, // Set the creation time
                AutoTimeUpdate = DateTime.Now, // Set the update time
                AutoUpdateCount = 0, // Set the update count
                IsDeleted = false, // Set the deletion flag
            };

            var addedTest = _context.Tests.Add(efTest).Entity;
            var count = _context.SaveChanges();

            test.TestId = addedTest.TestId; // Update the TestId with the generated ID

            _tests.Add(test.TestId, test);
        }

        public void Update(Test test)
        {
            if (_tests.ContainsKey(test.TestId))
            {
                // Update the corresponding EFRepository.Models.Test entity in the database
                var efTest = _context.Tests.Find(test.TestId);
                if (efTest != null)
                {
                    efTest.OfficialCode = test.OfficialCode;
                    efTest.CourseId = test.CourseId;
                    efTest.AutoTimeUpdate = DateTime.Now; // Update the update time
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(Test test)
        {
            if (_tests.ContainsKey(test.TestId))
            {
                // Delete the corresponding EFRepository.Models.Test entity from the database
                var efTest = _context.Tests.Find(test.TestId);
                if (efTest != null)
                {
                    _context.Tests.Remove(efTest);
                    _context.SaveChanges();
                }
                _tests.Remove(test.TestId);
            }
        }

        public bool Exists(Test test)
        {
            return _tests.ContainsKey(test.TestId);
        }
    }
}
#endif