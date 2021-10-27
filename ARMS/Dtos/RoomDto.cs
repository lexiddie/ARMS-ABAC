namespace ARMS.Dtos
{
    public class RoomDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public int ExamCapacity { get; set; }

        public int ExamRows { get; set; }

        public virtual long CampusId { get; set; }

        public virtual string CampusName { get; set; }

        public virtual long BuildingId { get; set; }

        public virtual string BuildingName { get; set; }

        public string CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}