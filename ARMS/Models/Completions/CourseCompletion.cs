namespace ARMS.Models.Completions
{
    public class CourseCompletion
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public long FacultyId { get; set; }

        public long DepartmentId { get; set; }
    }
}