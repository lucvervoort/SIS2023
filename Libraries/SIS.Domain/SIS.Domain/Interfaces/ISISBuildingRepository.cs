namespace SIS.Domain.Interfaces
{
    public interface ISISBuildingRepository
    {
        public Dictionary<string, Building> Buildings { get; }

        public Dictionary<string, Building> RefreshBuilding();
        public bool Exists(Building building);
        public void Insert(Building building);
        public void Update(Building buildingToUpdate, Building newBuilding);
        public void Delete(Building building);

    }
}
