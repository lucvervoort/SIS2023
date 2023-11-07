namespace SIS.Domain.Interfaces
{
    public interface ISISRoomRepository
    {
        public Dictionary<string, Room> Rooms { get; }

        public Dictionary<string, Room> RefreshRoom();
        public bool Exists(Room room);
        public void Insert(Room room);
        public void Update(Room roomToUpdate, Room newRoom);
        public void Delete(Room room);

    }
}
