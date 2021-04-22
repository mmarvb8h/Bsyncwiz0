using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

using Banksyncwiz.Config;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

public record Dumy { }

namespace Banksyncwiz.Services
{
   public class GetInstitutionList
   {
        public async Task<List<Dumy>> Doit(string searchStr)
        {
            var client = GetMyHttp.client;

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string url = QueryHelpers.AddQueryString(
                "http://127.0.0.1:3003/api/institutions/search", "institution_search_name", "");


            // Http status_code of 200 and 404 are ok.
            List<Dumy>? data = null;
            try
            {
                // To deserialize json to object, get stream reader and deserialize
                // to class.
                var streamTask = client.GetStreamAsync(url);
                data = await JsonSerializer.DeserializeAsync<List<Dumy>>(await streamTask);
            }
            catch (HttpRequestException e)
            {
                _HandleHttpRequestException(e);
            }
            catch (Exception e)
            {
                var excep = GetHttpStatus.HandleExceptionAsDefault(e);
                if (excep != null) throw excep; else throw;
            }

            return data;           
        }

        private void _HandleHttpRequestException(HttpRequestException e)
        {
            var statusInfo = GetHttpStatus.HandleHttpRequestException(e);
            if (!statusInfo.httpStatusCode.HasValue)
            {
                Console.Out.WriteLine(statusInfo.message);
                throw statusInfo.exception;
            }
        }

    }
}
