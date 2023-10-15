namespace SIS.Domain.Interfaces
{
    public interface ISISRepository
    {
        public Dictionary<string, Lector> Lectors { get; }
        public Dictionary<string, Lector> RefreshLectors();

        public void Add(Lector lector);
        public void SaveChanges();
    }
}