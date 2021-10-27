namespace ARMSAPI.Models
{
    public class FirebaseViewModel
    {
        public string errorMessage { get; set; } = "";
        public bool isAutomate { get; set; } = false;
        public bool isComputing { get; set; } = false;
        public bool isError { get; set; } = false;
        public bool isProcessing { get; set; } = false;
        public bool isRetrieving { get; set; } = false;
        public bool isUpdating { get; set; } = false;
    }
}