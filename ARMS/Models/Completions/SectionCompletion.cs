namespace ARMS.Models.Completions
{
    public class SectionCompletion
    {
        public long Id { get; set; }

        public string Number { get; set; }

        public long CourseId { get; set; }

        public int SeatUsed { get; set; }
    }
}
