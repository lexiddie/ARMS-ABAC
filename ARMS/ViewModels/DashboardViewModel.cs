namespace ARMS.ViewModels
{
    public class DashboardViewModel
    {
        public long SemesterId { get; set; }

        public long ExaminationTypeId { get; set; }

        public long ExaminationSlotId { get; set; }

        public long ExaminationRoomId { get; set; }

        public string ExaminationRoomName { get; set; }

        public int Campus { get; set; }

        public int Building { get; set; }

        public int Room { get; set; }

        public int ExaminationCourse { get; set; }

        public int AssignedCourse { get; set; }

        public int UnassignedCourse { get; set; }

        public string ExaminationRooms { get; set; }

        public string ExaminationStudents { get; set; }
    }
}