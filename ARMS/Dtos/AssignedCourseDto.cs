namespace ARMS.Dtos
{
    public class AssignedCourseDto
    {
        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }

        public long CourseId { get; set; }

        public string CourseName { get; set; }

        public string CourseCode { get; set; }

        public int TotalSection { get; set; }

        public int TotalStudent { get; set; }

        public int TotalRoom { get; set; }

        public ExaminationSlotDto ExaminationSlot { get; set; }

        public string CreatedBy { get; set; }
    }
}