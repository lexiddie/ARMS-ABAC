namespace ARMS.Helpers
{
    public class FilterString
    {
        public static string FilterRoomName(string roomName)
        {
            return roomName == null ? "" : roomName.Replace(".", "").Replace(" ", "");
        }
    }
}