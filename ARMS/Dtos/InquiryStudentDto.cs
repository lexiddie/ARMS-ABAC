using System.Collections.Generic;

namespace ARMS.Dtos
{
    public class InquiryStudentDto
    {
        public long Id { get; set; }

        public string StudentCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<CourseScheduleDto> ExaminationCourses { get; set; }
    }
}