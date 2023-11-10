#if JARI
using System;
using System.Collections.Generic;

namespace SIS.Domain.Interfaces
{
    public interface ITestRepository
    {
        Dictionary<int, Test> Tests { get; }

        Dictionary<int, Test> RefreshTests();

        void Insert(Test test);

        void Update(Test test);

        void Delete(Test test);

        bool Exists(Test test);
    }
}
#endif