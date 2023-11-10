#if JARI
namespace SIS.Domain.Interfaces
{
    public interface IPeriodRepository
    {
        Dictionary<int, Period> Periods { get; }

        Dictionary<int, Period> RefreshPeriods();

        void Insert(Period period);

        void Update(Period period);

        void Delete(Period period);

        bool Exists(Period period);
    }
}
#endif
