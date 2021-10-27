namespace ARMS.Models.Completions
{
    public class SemesterCompletion
    {
        public long Id { get; set; }

        public long AcademicLevelId { get; set; }

        public int AcademicYear { get; set; }

        public int Term { get; set; }

        public bool IsCurrent { get; set; }

        public string SemesterText => $"{ Term }/{ AcademicYear }";
    }
}