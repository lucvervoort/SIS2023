#if JARI
using System;
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IRubricInstanceRepository
    {
        Dictionary<int, RubricInstance> RubricInstances { get; }

        Dictionary<int, RubricInstance> RefreshRubricInstances();

        void Insert(RubricInstance rubricInstance);

        void Update(RubricInstance rubricInstance);

        void Delete(RubricInstance rubricInstance);

        bool Exists(RubricInstance rubricInstance);
    }
}
#endif