using System.Collections.Generic;

namespace ARMS.Models
{
    public class ConflictStudent
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<long> CourseIds { get; set; }

        public ExaminationSlot ExaminationSlot { get; set; }

        // public string FullName => $"{ FirstName } { LastName }";
        
        public string FullName => $"{FirstName} {LastName.Substring(0, 1)}.";

        public string TotalConflict => $"{CourseIds.Count}";
    }
}