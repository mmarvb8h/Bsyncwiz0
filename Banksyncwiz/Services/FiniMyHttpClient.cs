using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.WebUtilities;

using Banksyncwiz.Config;

namespace Banksyncwiz.Services
{
    public class FiniMyHttpClientGet
    {
        public record ResponseData<TValue>
        {
            public HttpStatusCode? httpStatus { get; init; }
            public TValue? data { get; init; }
        }

        const string _baseUrl = "http://127.0.0.1:3003";
        private readonly string _fullUrl;
        private HttpClient _httpclient;

        public FiniMyHttpClientGet(string urlPath, HttpClient httpclient)
        {
            _fullUrl = _baseUrl + urlPath;
            _httpclient = httpclient;
        }

        public void PrepHeaders(HttpClient httpclient)
        {
            httpclient.DefaultRequestHeaders.Accept.Clear();
            httpclient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpclient.DefaultRequestHeaders.Add("K-Rednes", "93109ea8-ffac-4f13-8a11-a92e5b5250b5");
        }

        public async Task<HttpResponseMessage> GetAsync(List<KeyValuePair<string, string?>>? queryParams)
        {
            string url =
                queryParams != null ? QueryHelpers.AddQueryString(_fullUrl, queryParams) : _fullUrl;
            return await _httpclient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        }
    }

}
