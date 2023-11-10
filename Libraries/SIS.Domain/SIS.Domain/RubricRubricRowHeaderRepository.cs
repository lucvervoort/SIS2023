#if JARI
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IRubricRubricRowHeaderRepository
    {
        Dictionary<int, RubricRubricRowHeader> RubricRubricRowHeaders { get; }
        Dictionary<int, RubricRubricRowHeader> RefreshRubricRubricRowHeaders();
        void Insert(RubricRubricRowHeader rubricRubricRowHeader);
        void Update(RubricRubricRowHeader rubricRubricRowHeader);
        void Delete(RubricRubricRowHeader rubricRubricRowHeader);
        bool Exists(RubricRubricRowHeader rubricRubricRowHeader);
    }
}
#endif