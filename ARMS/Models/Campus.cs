namespace ARMS.Models
{
    public class Campus
    {
        public long Id { get; set; }

        public string NameEn { get; set; }

        public string NameTh { get; set; }

        public int TotalBuilding { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedTime { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }

    }
}