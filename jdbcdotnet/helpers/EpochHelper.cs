using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jdbcdotnet.helpers
{
    public static class EpochHelper
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long ToEpochMs(this DateTime value)
        {
            TimeSpan span = value - epoch;
            return (long)span.TotalMilliseconds;
        }

        public static DateTime FromEpochMsToDate(this long epochValue)
        {
            return epoch.AddMilliseconds(epochValue);
        }
    }
}
