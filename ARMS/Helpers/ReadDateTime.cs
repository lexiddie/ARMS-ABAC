using System;

namespace ARMS.Helpers
{
    public static class ReadDateTime
    {
        public static string ReadDate(string dateTime = "2019-07-27T11:46:14.6233333")
        {
            var arr = dateTime.Split('T')[0];
            var year = arr.Split("-")[0];
            var month = arr.Split("-")[1];
            var day = arr.Split("-")[2];
            return $"{day}/{month}/{year}";    
        }

        public static string ReadTime(string dateTime = "2019-07-27T11:46:14.6233333")
        {
            var arr = dateTime.Split('T')[1];
            var hour = arr.Split(":")[0];
            var minute = arr.Split(":")[1];
            return $"{hour}:{minute}";
        }

        public static string ReadRealTime(string time = "12:00:00")
        {
            var hour = time.Split(":")[0];
            var minute = time.Split(":")[1];
            return $"{hour}:{minute}";
        }

        public static string ReadTimeSpan(TimeSpan timeSpan)
        {
            var hour = timeSpan.ToString().Split(":")[0];
            var minute = timeSpan.ToString().Split(":")[1];
            return $"{hour}:{minute}";
        }
    }
}