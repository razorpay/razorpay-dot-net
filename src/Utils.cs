using System;

namespace Razorpay.Api
{
    public class Utils
    {    
        public static long ToUnixTimestamp(DateTime inputTime)
        {
            DateTime unixReferenceTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = inputTime - unixReferenceTime;
            return (long)diff.TotalSeconds;
        }

        public static long ToUnixTimestamp(long ticks)
        {
            return ToUnixTimestamp(new DateTime(ticks, DateTimeKind.Utc));
        }

        public static DateTime FromUnixTimestamp(long timestamp)
        {
            DateTime unixReferenceTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixReferenceTime.Add(TimeSpan.FromSeconds(timestamp));
        }
    }
}