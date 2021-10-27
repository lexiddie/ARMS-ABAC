using System.Collections.Generic;
using ARMS.Models;

namespace ARMS.ViewModels
{
    public class ConflictCourseViewModel
    {
        public string StudentCode { get; set; }
        
        public string StudentName { get; set; }
        
        public string ExaminationDateTime { get; set; }
        
        public List<long> CourseIds { get; set; }

        public string ConflictCourses { get; set; }
    }
}