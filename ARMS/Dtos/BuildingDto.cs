namespace ARMS.Dtos
{
    public class BuildingDto
    {
        public long Id { get; set; }

        public string NameEn { get; set; }

        public string NameTh { get; set; }

        public int FloorNumber { get; set; }

        public int TotalRoom { get; set; }

        public virtual long CampusId { get; set; }

        public virtual string CampusName { get; set; }

        public string CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}