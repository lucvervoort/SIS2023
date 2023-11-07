namespace SIS.Domain.Interfaces
{
    public interface ISISLocationRepository
    {
        public Dictionary<string, Location> Locations { get; }

        public Dictionary<string, Location> RefreshLocation();
        public bool Exists(Location location);
        public void Insert(Location location);
        public void Update(Location locationToUpdate, Location newLocation);
        public void Delete(Location location);
    }
}
