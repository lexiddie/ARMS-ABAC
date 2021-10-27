namespace ARMS.Models
{
    public class Semester
    {
        public long Id { get; set; }

        public long AcademicLevelId { get; set; }

        public int AcademicYear { get; set; }

        public int Term { get; set; }

        public bool IsCurrent { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string MidtermStartDate { get; set; }

        public string MidtermEndDate { get; set; }

        public string FinalStartDate { get; set; }

        public string FinalEndDate { get; set; }

        public int TotalWeek { get; set; }

        public string SemesterText => $"{ Term }/{ AcademicYear }";

        public string CreatedDate { get; set; }

        public string CreatedTime { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}