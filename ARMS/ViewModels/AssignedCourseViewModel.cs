namespace ARMS.ViewModels
{
    public class AssignedCourseViewModel
    {
        public long SemesterId { get; set; }

        public long ExaminationTypeId { get; set; }
        
        public string SessionText { get; set; }
        
        public string AssignedCourses { get; set; }
    }
}