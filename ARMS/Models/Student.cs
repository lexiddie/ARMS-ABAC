namespace ARMS.Models
{
    public class Student
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string FullName => $"{FirstName} {LastName.Substring(0, 1)}.";

        public string CreatedDate { get; set; }

        public string CreatedTime { get; set; }

        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
    }
}