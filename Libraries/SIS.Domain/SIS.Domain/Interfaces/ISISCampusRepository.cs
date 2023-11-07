namespace SIS.Domain.Interfaces
{
    public interface ISISCampusRepository
    {
        public Dictionary<string, Campus> Campus { get; }

        public Dictionary<string, Campus> RefreshCampus();
        public bool Exists(Campus campus);
        public Campus Insert(Campus campus);
        public void Update(Campus campusToUpdate, Campus newCampus);
        public void Delete(Campus campus);
    }
}
