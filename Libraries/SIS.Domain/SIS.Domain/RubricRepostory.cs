#if JARI
using SIS.Domain;
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface IRubricRepository
    {
        Dictionary<int, Rubric> Rubrics { get; }

        Dictionary<int, Rubric> RefreshRubrics();

        void Insert(Rubric rubric);

        void Update(Rubric rubric);

        void Delete(Rubric rubric);

        bool Exists(Rubric rubric);
    }
}
#endif