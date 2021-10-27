namespace ARMS.Dtos
{
    public class SemesterDto
    {
        public long Id { get; set; }

        public long AcademicLevelId { get; set; }

        public int AcademicYear { get; set; }

        public int Term { get; set; }

        public decimal TotalWeekCount { get; set; }

        public bool IsCurrent { get; set; }

        public string StartedDate { get; set; }

        public string EndedDate { get; set; }

        public string MidtermStartDate { get; set; }

        public string MidtermEndDate { get; set; }

        public string FinalStartDate { get; set; }

        public string FinalEndDate { get; set; }

        public string CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}