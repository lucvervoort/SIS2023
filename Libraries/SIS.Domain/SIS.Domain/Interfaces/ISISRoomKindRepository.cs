namespace SIS.Domain.Interfaces
{
    public interface ISISRoomKindRepository
    {
        public Dictionary<string, RoomKind> RoomKinds { get; }

        public Dictionary<string, RoomKind> RefreshRoomKind();
        public bool Exists(RoomKind roomKind);
        public void Insert(RoomKind roomKind);
        public void Update(RoomKind roomKindToUpdate, RoomKind newRoomKind);
        public void Delete(RoomKind roomKind);
    }
}
