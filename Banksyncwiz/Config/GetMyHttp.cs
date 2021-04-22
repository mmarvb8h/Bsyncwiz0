using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;

namespace Banksyncwiz.Config
{
    public static class GetMyHttp
    {
        static HttpClient? _client;
        public static HttpClient client
        {
            get
            {
                if (_client == null)
                {
                    var msgHandler = new SocketsHttpHandler()
                    {
                        PooledConnectionLifetime = SetHttpServicePointMgr.connectionLifeTime,
                        PooledConnectionIdleTimeout = SetHttpServicePointMgr.connectionLifeTime,
                        MaxConnectionsPerServer = SetHttpServicePointMgr.MAX_CONNECTION_PER_SERVER,
                    };
                    _client = new HttpClient(msgHandler, true);
                }
                return _client;
            }
        }

    }
}
