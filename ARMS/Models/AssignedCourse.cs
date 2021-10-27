namespace ARMS.Models
{
    public class AssignedCourse
    {
        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }

        public long CourseId { get; set; }

        public string CourseName { get; set; }

        public string CourseCode { get; set; }

        public int TotalSection { get; set; }

        public int TotalStudent { get; set; }

        public int TotalRoom { get; set; }

        public ExaminationSlot ExaminationSlot { get; set; }

        public string CodeAndName => $"{ CourseCode } { CourseName }";

        public string CreatedBy { get; set; }
    }
}