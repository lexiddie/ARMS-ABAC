namespace ARMS.Models
{
    public class Section
    {
        public long Id { get; set; }

        public string Number { get; set; }

        public long CourseId { get; set; }

        public int SeatUsed { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedTime { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}