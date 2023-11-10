#if JARI
using SIS.Domain;
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IRubricRubricColumnRepository
    {
        Dictionary<int, RubricRubricColumn> RubricRubricColumns { get; }
        Dictionary<int, RubricRubricColumn> RefreshRubricRubricColumns();
        void Insert(RubricRubricColumn rubricRubricColumn);
        void Update(RubricRubricColumn rubricRubricColumn);
        void Delete(RubricRubricColumn rubricRubricColumn);
        bool Exists(RubricRubricColumn rubricRubricColumn);
    }
}
#endif