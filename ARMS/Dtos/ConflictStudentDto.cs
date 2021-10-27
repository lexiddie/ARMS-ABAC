using System.Collections.Generic;
using ARMS.Models;

namespace ARMS.Dtos
{
    public class ConflictStudentDto
    {
        public long StudentId { get; set; }

        public List<CourseId> CourseIds { get; set; }

        public long ExaminationSlotId { get; set; }
    }
}