namespace ARMS.Dtos
{
    public class SectionDto
    {
        public long Id { get; set; }

        public string Number { get; set; }

        public long CourseId { get; set; }

        public int SeatUsed { get; set; }

        public string CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}