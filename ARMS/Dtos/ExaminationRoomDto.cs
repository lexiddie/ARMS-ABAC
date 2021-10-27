namespace ARMS.Dtos
{
    public class ExaminationRoomDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public long CampusId { get; set; }

        public string CampusName { get; set; }

        public long BuildingId { get; set; }

        public string BuildingName { get; set; }

        public int TotalSeat { get; set; }

        public int TotalSection { get; set; }

        public int TotalStudent { get; set; }

        public string CreatedAt { get; set; }

        public string CreatedBy { get; set; }

    }
}