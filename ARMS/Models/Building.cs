namespace ARMS.Models
{
    public class Building
    {
        public long Id { get; set; }

        public string NameEn { get; set; }

        public string NameTh { get; set; }

        public int TotalFloor { get; set; }
        
        public int TotalRoom { get; set; }

        public virtual long CampusId { get; set; }

        public virtual string CampusName { get; set; }
        
        public string CreatedDate { get; set; }

        public string CreatedTime { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}