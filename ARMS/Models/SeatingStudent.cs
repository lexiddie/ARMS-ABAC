namespace ARMS.Models
{
    public class SeatingStudent
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CourseCode { get; set; }
        
        public string Section { get; set; }

        public int Row { get; set; }
        
        public int Seat { get; set; }
        
        public string SeatNumber => $"{Row}/{Seat}";
        
        public string FullName => $"{FirstName} {LastName.Substring(0, 1)}.";
    }
}