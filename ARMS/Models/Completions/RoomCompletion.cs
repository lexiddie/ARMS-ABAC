namespace ARMS.Models.Completions
{
    public class RoomCompletion
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public int ExamCapacity { get; set; }

        public long CampusId { get; set; }

        public long BuildingId { get; set; }

        public string Text => $"{ Name } ({ ExamCapacity })";
    }
}