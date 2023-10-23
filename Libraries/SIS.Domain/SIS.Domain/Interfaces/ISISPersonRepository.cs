namespace SIS.Domain.Interfaces
{
    public interface ISISPersonRepository
    {
        public Dictionary<string, Person> Persons { get; }

        public Dictionary<string, Person> RefreshPersons();
        public bool Exists(Person person);
        public void Insert(Person person);
        public void Update(Person person);
        public void Delete(Person person);
    }
}