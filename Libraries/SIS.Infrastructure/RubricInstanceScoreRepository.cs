using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SIS.Domain.Interfaces;
using SIS.Infrastructure.EFRepository.Context;
#if JARI
namespace SIS.Infrastructure
{
    public class EFRubricInstanceScoreRepository : IRubricInstanceScoreRepository
    {
        private readonly ILogger<EFRubricInstanceScoreRepository> _logger;
        private readonly IConfiguration _configuration;
        private readonly SisDbContext _context;

        private Dictionary<int, RubricInstanceScore> _rubricInstanceScores;
        public Dictionary<int, RubricInstanceScore> RubricInstanceScores
        {
            get
            {
                if (_rubricInstanceScores != null) return _rubricInstanceScores;
                return RefreshRubricInstanceScores();
            }
        }

        public EFRubricInstanceScoreRepository(ILogger<EFRubricInstanceScoreRepository> logger, IConfiguration configuration, SisDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;

            // Load all RubricInstanceScores up front
            RefreshRubricInstanceScores();
        }

        public Dictionary<int, RubricInstanceScore> RefreshRubricInstanceScores()
        {
            _rubricInstanceScores = new();
            var dbRubricInstanceScores = _context.RubricInstanceScores
                .Include(ris => ris.RubricInstance)
                .Include(ris => ris.RubricRubricColumn)
                .Include(ris => ris.RubricRubricRow)
                .ToList();

            foreach (var rubricInstanceScore in dbRubricInstanceScores)
            {
                var ris = new RubricInstanceScore
                {
                    RubricInstanceScoreId = rubricInstanceScore.RubricInstanceScoreId,
                    RubricInstanceId = rubricInstanceScore.RubricInstanceId,
                    RubricRubricRowId = rubricInstanceScore.RubricRubricRowId,
                    RubricRubricColumnId = rubricInstanceScore.RubricRubricColumnId,
                    Score = rubricInstanceScore.Score,
                    AutoTimeCreation = rubricInstanceScore.AutoTimeCreation,
                    AutoTimeUpdate = rubricInstanceScore.AutoTimeUpdate,
                    AutoUpdateCount = rubricInstanceScore.AutoUpdateCount,
                    IsDeleted = rubricInstanceScore.IsDeleted,
                };
                _rubricInstanceScores.Add(ris.RubricInstanceScoreId, ris);
            }
            return _rubricInstanceScores;
        }

        public void Insert(RubricInstanceScore rubricInstanceScore)
        {
            if (_rubricInstanceScores.ContainsKey(rubricInstanceScore.RubricInstanceScoreId))
                return;

            var efRubricInstanceScore = new EFRepository.Models.RubricInstanceScore
            {
                RubricInstanceId = rubricInstanceScore.RubricInstanceId,
                RubricRubricRowId = rubricInstanceScore.RubricRubricRowId,
                RubricRubricColumnId = rubricInstanceScore.RubricRubricColumnId,
                Score = rubricInstanceScore.Score,
                AutoTimeCreation = DateTime.Now, // Set the creation time
                AutoTimeUpdate = DateTime.Now, // Set the update time
                AutoUpdateCount = 0, // Set the update count
                IsDeleted = false, // Set the deletion flag
            };

            var addedRubricInstanceScore = _context.RubricInstanceScores.Add(efRubricInstanceScore).Entity;
            var count = _context.SaveChanges();

            rubricInstanceScore.RubricInstanceScoreId = addedRubricInstanceScore.RubricInstanceScoreId; // Update the RubricInstanceScoreId with the generated ID

            _rubricInstanceScores.Add(rubricInstanceScore.RubricInstanceScoreId, rubricInstanceScore);
        }

        public void Update(RubricInstanceScore rubricInstanceScore)
        {
            if (_rubricInstanceScores.ContainsKey(rubricInstanceScore.RubricInstanceScoreId))
            {
                // Update the corresponding EFRepository.Models.RubricInstanceScore entity in the database
                var efRubricInstanceScore = _context.RubricInstanceScores.Find(rubricInstanceScore.RubricInstanceScoreId);
                if (efRubricInstanceScore != null)
                {
                    efRubricInstanceScore.RubricInstanceId = rubricInstanceScore.RubricInstanceId;
                    efRubricInstanceScore.RubricRubricRowId = rubricInstanceScore.RubricRubricRowId;
                    efRubricInstanceScore.RubricRubricColumnId = rubricInstanceScore.RubricRubricColumnId;
                    efRubricInstanceScore.Score = rubricInstanceScore.Score;
                    efRubricInstanceScore.AutoTimeUpdate = DateTime.Now; // Update the update time
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(RubricInstanceScore rubricInstanceScore)
        {
            if (_rubricInstanceScores.ContainsKey(rubricInstanceScore.RubricInstanceScoreId))
            {
                // Delete the corresponding EFRepository.Models.RubricInstanceScore entity from the database
            }
        }
    }
}
#endif