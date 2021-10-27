namespace ARMS.ViewModels
{
    public class SeatingRoomViewModel
    {
        public long CampusId { get; set; }

        public long BuildingId { get; set; }

        public long RoomId { get; set; }

        public int Floor { get; set; }

        public string SeatingRooms { get; set; }
    }
}