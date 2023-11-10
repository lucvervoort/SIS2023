#if JARI
using System;
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IRubricInstanceScoreRepository
    {
        Dictionary<int, RubricInstanceScore> RubricInstanceScores { get; }

        Dictionary<int, RubricInstanceScore> RefreshRubricInstanceScores();

        void Insert(RubricInstanceScore rubricInstanceScore);

        void Update(RubricInstanceScore rubricInstanceScore);

        void Delete(RubricInstanceScore rubricInstanceScore);

        bool Exists(RubricInstanceScore rubricInstanceScore);
    }
}
#endif