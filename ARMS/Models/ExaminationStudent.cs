namespace ARMS.Models
{
    public class ExaminationStudent
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string FullName => $"{FirstName} {LastName.Substring(0, 1)}.";

        public string SectionNumber { get; set; }

        public int Seat { get; set; }

        public int Row { get; set; }

        public string CreatedDate { get; set; }

        public string CreatedTime { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}