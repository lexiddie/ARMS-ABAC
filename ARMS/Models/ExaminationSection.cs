namespace ARMS.Models
{
    public class ExaminationSection
    {
        public long Id { get; set; }

        public string Number { get; set; }

        public long CampusId { get; set; }

        public string CampusName { get; set; }

        public int SeatUsed { get; set; }
    }
}