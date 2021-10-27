namespace ARMS.ViewModels
{
    public class RoomSearchViewModel
    {
        public long CampusId { get; set; }

        public long BuildingId { get; set; }

        public long RoomId { get; set; }

        public int Floor { get; set; }
        
        public long ExaminationSlotId { get; set; }

        public string Rooms { get; set; }
    }
}