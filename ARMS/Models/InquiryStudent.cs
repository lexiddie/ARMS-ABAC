using System.Collections.Generic;

namespace ARMS.Models
{
    public class InquiryStudent
    {
        public long Id { get; set; }

        public string StudentCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string FullName => $"{FirstName} {LastName.Substring(0, 1)}.";

        public List<CourseSchedule> ExaminationCourses { get; set; }
    }
}