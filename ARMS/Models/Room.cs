namespace ARMS.Models
{
    public class Room
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual int Floor { get; set; }

        public virtual int TotalSeat { get; set; }

        public virtual int TotalRow { get; set; }

        public virtual long CampusId { get; set; }

        public virtual string CampusName { get; set; }

        public virtual long BuildingId { get; set; }

        public virtual string BuildingName { get; set; }

        public virtual string CreatedDate { get; set; }

        public virtual string CreatedTime { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual bool IsActive { get; set; }
    }
}