using System.Net;
using System.Net.Http;

namespace Banksyncwiz.Services
{
    public class MyHttpResponseStatusException : HttpRequestException
    {
        public MyHttpResponseStatusException(string message, HttpStatusCode httpstatus)
            : base(message, null, httpstatus)
        {}
    }
}
