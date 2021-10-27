namespace ARMS.Models
{
    public class ExaminationSlot
    {
        public long Id { get; set; }

        public string Date { get; set; }

        public string TimeStart { get; set; }

        public string TimeEnd { get; set; }

        public string ExaminationDateTime => $"{Date} { TimeStart } - { TimeEnd }";

    }
}