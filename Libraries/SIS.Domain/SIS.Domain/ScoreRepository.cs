#if JARI
using System;
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IScoreRepository
    {
        Dictionary<int, Score> Scores { get; }

        Dictionary<int, Score> RefreshScores();

        void Insert(Score score);

        void Update(Score score);

        void Delete(Score score);

        bool Exists(Score score);
    }
}
#endif