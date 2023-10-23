namespace SIS.Domain.Interfaces
{

    public interface ISISTeacherRepository
    {
        public Dictionary<string, Teacher> Teachers { get; }

        public Dictionary<string, Teacher> RefreshTeachers();
        public bool Exists(Teacher teacher);
        public void Insert(Teacher teacher);
        public void Update(Teacher teacher);
        public void Delete(Teacher teacher);

        // RAW SQL Example:
        IEnumerable<string> GetNames();
    }
}