namespace ARMS.Models.Completions
{
    public class BuildingCompletion
    {
        public long Id { get; set; }

        public string NameEn { get; set; }

        public int FloorNumber { get; set; }

        public long CampusId { get; set; }
    }
}