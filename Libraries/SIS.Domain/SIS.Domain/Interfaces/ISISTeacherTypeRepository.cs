namespace SIS.Domain.Interfaces
{

    public interface ISISTeacherTypeRepository
    {
        public Dictionary<string, TeacherType> TeacherTypes { get; }

        public Dictionary<string, TeacherType> RefreshTeacherTypes();
        public bool Exists(TeacherType teacherType);
        public void Insert(TeacherType teacherType);
        public void Update(TeacherType teacherType);
        public void Delete(TeacherType teacherType);
    }
}