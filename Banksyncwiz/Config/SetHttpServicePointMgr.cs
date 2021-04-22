using System;
using System.Net;

namespace Banksyncwiz.Config
{
   public static class SetHttpServicePointMgr
   {
        public const int MAX_CONNECTION_PER_SERVER = 24;
        public static readonly TimeSpan connectionLifeTime = TimeSpan.FromMinutes(1);

        public static void ConfigureIt()
        {
            ServicePointManager.DnsRefreshTimeout = (int)connectionLifeTime.TotalMilliseconds;

            // Increases the concurrent outbound connections
            ServicePointManager.DefaultConnectionLimit = MAX_CONNECTION_PER_SERVER;
        }
    }
}
