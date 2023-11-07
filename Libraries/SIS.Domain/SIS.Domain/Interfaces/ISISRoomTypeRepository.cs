namespace SIS.Domain.Interfaces
{
    public interface ISISRoomTypeRepository
    {
        public Dictionary<string, RoomType> RoomTypes { get; }

        public Dictionary<string, RoomType> RefreshRoomType();
        public bool Exists(RoomType roomType);
        public void Insert(RoomType roomType);
        public void Update(RoomType roomTypeToUpdate, RoomType newRoomType);
        public void Delete(RoomType roomType);

    }
}
