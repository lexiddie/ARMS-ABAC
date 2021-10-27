namespace ARMS.ViewModels
{
    public class ExaminationStudentViewModel
    {
        public long ExaminationSlotId { get; set; }

        public long CourseId { get; set; }

        public string CourseCodeName { get; set; }

        public long RoomId { get; set; }

        public string RoomName { get; set; }
        
        public string ExaminationStudents { get; set; }
    }
}