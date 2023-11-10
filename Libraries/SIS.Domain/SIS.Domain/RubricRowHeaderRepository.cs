#if JARI
using SIS.Domain;
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IRubricRowHeaderRepository
    {
        Dictionary<int, RubricRowHeader> RubricRowHeaders { get; }
        Dictionary<int, RubricRowHeader> RefreshRubricRowHeaders();
        void Insert(RubricRowHeader rubricRowHeader);
        void Update(RubricRowHeader rubricRowHeader);
        void Delete(RubricRowHeader rubricRowHeader);
        bool Exists(RubricRowHeader rubricRowHeader);
    }
}
#endif