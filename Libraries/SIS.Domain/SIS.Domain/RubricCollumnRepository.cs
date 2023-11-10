#if JARI
using SIS.Domain;
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IRubricColumnRepository
    {
        Dictionary<int, RubricColumn> RubricColumns { get; }

        Dictionary<int, RubricColumn> RefreshRubricColumns();

        void Insert(RubricColumn rubricColumn);

        void Update(RubricColumn rubricColumn);

        void Delete(RubricColumn rubricColumn);

        bool Exists(RubricColumn rubricColumn);
    }
}
#endif