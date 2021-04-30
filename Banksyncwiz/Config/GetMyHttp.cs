using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace Banksyncwiz.Config
{
    public static class GetMyHttp
    {
        public static HttpClient client
        {
            get
            {
                var msgHandler = new SocketsHttpHandler()
                {
                    PooledConnectionLifetime = SetHttpServicePointMgr.connectionLifeTime,
                    PooledConnectionIdleTimeout = SetHttpServicePointMgr.connectionLifeTime,
                    MaxConnectionsPerServer = SetHttpServicePointMgr.MAX_CONNECTION_PER_SERVER,
                };
                return new HttpClient(msgHandler);
            }
        }

    }
}
