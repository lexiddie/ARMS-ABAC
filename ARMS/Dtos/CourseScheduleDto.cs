namespace ARMS.Dtos
{
    public class CourseScheduleDto
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
    }
}