using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

using Banksyncwiz.Config;

namespace Banksyncwiz.Services
{
    public static class FiniObjectGetRequest
    {
        public record ResponseData<TValue>
        {
            public HttpStatusCode? httpStatus { get; init; }
            public TValue? data { get; init; }
        }

        public static async Task<ResponseData<TValue>> Begin<TValue>(
            FiniMyHttpClientGet finiclient,
            List<KeyValuePair<string, string?>>? queryParams,
            Func<HttpResponseMessage, bool> callerDidValidation) where TValue : class, new()
        {
            // Call endpoint.
            using var httpResponse = await finiclient.GetAsync(queryParams);

            // Did caller validate? If so we will skip MS validation.
            if (!callerDidValidation(httpResponse)) 
            {
                // Caller did not validate so we will.
                // throws if not 200-299.
                httpResponse.EnsureSuccessStatusCode();
            }

            // Call to get json from response.
            var jsondata = await GetHttpJsonObject.Begin<TValue>(httpResponse);
            return new ResponseData<TValue>
            {
                httpStatus = httpResponse.StatusCode,
                data = jsondata
            };
        }
    }

}
