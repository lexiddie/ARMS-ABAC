namespace ARMS.Models
{
    public class CourseSchedule
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string SectionNumber { get; set; }
        
        public string RoomName { get; set; }

        public string Seat { get; set; }

        public string ExamDate { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
        
        public string ExaminationDateTime => $"{ExamDate} { StartTime } - { EndTime }";

        public string CodeAndName => $"{ Code } { Name }";
    }
}