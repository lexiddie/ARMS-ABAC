namespace ARMS.Dtos
{
    public class CampusDto
    {
        public long Id { get; set; }

        public string NameEn { get; set; }

        public string NameTh { get; set; }

        public int TotalBuilding { get; set; }

        public string CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}