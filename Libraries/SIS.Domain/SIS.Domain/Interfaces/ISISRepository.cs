namespace SIS.Domain.Interfaces
{
    public interface ISISRepository
    {
        public Dictionary<string, Teacher> Teachers { get; }

        public Dictionary<string, Teacher> RefreshTeachers();
        public void Add(Teacher lector);
        public void SaveChanges();
    }
}