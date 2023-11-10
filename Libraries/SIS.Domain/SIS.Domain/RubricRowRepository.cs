#if JARI
using SIS.Domain;
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IRubricRowRepository
    {
        Dictionary<int, RubricRow> RubricRows { get; }
        Dictionary<int, RubricRow> RefreshRubricRows();
        void Insert(RubricRow rubricRow);
        void Update(RubricRow rubricRow);
        void Delete(RubricRow rubricRow);
        bool Exists(RubricRow rubricRow);
    }
}
#endif