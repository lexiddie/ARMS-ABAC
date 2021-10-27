namespace ARMS.ViewModels
{
    public class ExaminationCourseSearchViewModel
    {
        public long SemesterId { get; set; }

        public long CourseId { get; set; }

        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }
        
        public string ExaminationCourses { get; set; }
    }
}