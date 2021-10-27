namespace ARMSAPI.Models
{
    public class Path
    {
        public const string BaseUrl = "replace-your-firebase-api-key";
        
        public const string Assigning = "assigning/";
        public static readonly string IsUpdating = $"{Assigning}isUpdating";
        public static readonly string IsError = $"{Assigning}isError";
        public static readonly string IsProcessing = $"{Assigning}isProcessing";
        public static readonly string IsComputing = $"{Assigning}isComputing";
        public static readonly string IsRetrieving = $"{Assigning}isRetrieving";
        public static readonly string ErrorMessage = $"{Assigning}errorMessage";
        public static readonly string IsAutomate = $"{Assigning}isAutomate";

        private const string Dissolving = "dissolving/";
        public static readonly string IsDissolving = $"{Dissolving}isDissolving";
    }
}