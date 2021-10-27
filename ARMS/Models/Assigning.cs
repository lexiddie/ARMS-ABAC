namespace ARMS.Models
{
    public class Assigning
    {
        public bool IsProcessing { get; set; }
        
        public bool IsRetrieving { get; set; }
        
        public bool IsComputing { get; set; }
        
        public bool IsUpdating { get; set; }
        
        public bool IsError { get; set; }
        
        public string ErrorMessage { get; set; }
    }
}