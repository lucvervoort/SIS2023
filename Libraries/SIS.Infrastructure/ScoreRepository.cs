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
    public class EFScoreRepository : IScoreRepository
    {
        private readonly ILogger<EFScoreRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, Score> _scores;
        public Dictionary<int, Score> Scores
        {
            get
            {
                if (_scores != null) return _scores;
                return RefreshScores();
            }
        }

        public EFScoreRepository(ILogger<EFScoreRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all scores up front
            RefreshScores();
        }

        public Dictionary<int, Score> RefreshScores()
        {
            _scores = new();
            var dbScores = _context.Scores.Include(s => s.Test).ToList();
            foreach (var score in dbScores)
            {
                var s = new Score
                {
                    ScoreId = score.ScoreId,
                    TotalPercentage = score.TotalPercentage,
                    Total = score.Total,
                    TestId = score.TestId,
                    AutoTimeCreation = score.AutoTimeCreation,
                    AutoTimeUpdate = score.AutoTimeUpdate,
                    AutoUpdateCount = score.AutoUpdateCount,
                    IsDeleted = score.IsDeleted,
                };
                _scores.Add(s.ScoreId, s);
            }
            return _scores;
        }

        public void Insert(Score score)
        {
            if (_scores.ContainsKey(score.ScoreId))
                return;

            var efScore = new EFRepository.Models.Score
            {
                TotalPercentage = score.TotalPercentage,
                Total = score.Total,
                TestId = score.TestId,
                AutoTimeCreation = DateTime.Now, // Set the creation time
                AutoTimeUpdate = DateTime.Now, // Set the update time
                AutoUpdateCount = 0, // Set the update count
                IsDeleted = false, // Set the deletion flag
            };

            var addedScore = _context.Scores.Add(efScore).Entity;
            var count = _context.SaveChanges();

            score.ScoreId = addedScore.ScoreId; // Update the ScoreId with the generated ID

            _scores.Add(score.ScoreId, score);
        }

        public void Update(Score score)
        {
            if (_scores.ContainsKey(score.ScoreId))
            {
                // Update the corresponding EFRepository.Models.Score entity in the database
                var efScore = _context.Scores.Find(score.ScoreId);
                if (efScore != null)
                {
                    efScore.TotalPercentage = score.TotalPercentage;
                    efScore.Total = score.Total;
                    efScore.TestId = score.TestId;
                    efScore.AutoTimeUpdate = DateTime.Now; // Update the update time
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(Score score)
        {
            if (_scores.ContainsKey(score.ScoreId))
            {
                // Delete the corresponding EFRepository.Models.Score entity from the database
                var efScore = _context.Scores.Find(score.ScoreId);
                if (efScore != null)
                {
                    _context.Scores.Remove(efScore);
                    _context.SaveChanges();
                }
                _scores.Remove(score.ScoreId);
            }
        }

        public bool Exists(Score score)
        {
            return _scores.ContainsKey(score.ScoreId);
        }
    }
}
#endif