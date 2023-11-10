#if JARI
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IRubricRubricRowRepository
    {
        Dictionary<int, RubricRubricRow> RubricRubricRows { get; }
        Dictionary<int, RubricRubricRow> RefreshRubricRubricRows();
        void Insert(RubricRubricRow rubricRubricRow);
        void Update(RubricRubricRow rubricRubricRow);
        void Delete(RubricRubricRow rubricRubricRow);
        bool Exists(RubricRubricRow rubricRubricRow);
    }
}
#endif