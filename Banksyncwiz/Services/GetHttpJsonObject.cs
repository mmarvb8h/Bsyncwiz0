using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace Banksyncwiz.Services
{
    public static class GetHttpJsonObject
    {

        public static async Task<TValue?> Begin<TValue>(
            HttpResponseMessage httpResponse) where TValue : class, new()
        {
            // Does it look ok to deserialize?
            if (httpResponse.Content is object)
            {
                if (httpResponse.Content.Headers.ContentType != null
                    && httpResponse.Content.Headers.ContentType.MediaType != null
                    && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                {
                    // We have json. Try to deserialize.
                    var contentStream = await httpResponse.Content.ReadAsStreamAsync();
                    var options = new System.Text.Json.JsonSerializerOptions
                    {
                        IgnoreNullValues = true,
                        PropertyNameCaseInsensitive = true
                    };
                    var jsondata = await System.Text.Json.JsonSerializer.DeserializeAsync<TValue>(contentStream, options);
                    return jsondata;
                }
            }

            return null;
        }
    }

}
