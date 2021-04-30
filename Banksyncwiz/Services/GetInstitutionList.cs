using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

using Banksyncwiz.Config;
using Banksyncwiz.Models;

namespace Banksyncwiz.Services
{
   public class GetInstitutionList
   {
        public async Task<FiniInstitutList> Begin(string searchStr, HttpClient httpclient)
        {
            var finiclient = new FiniMyHttpClientGet("/api/institutions/search", httpclient);
            finiclient.PrepHeaders(httpclient);

            // Setup query parameters.
            var queryParams = new List<KeyValuePair<string, string?>>(1);
            queryParams.Add(new KeyValuePair<string, string?>("institution_search_name", searchStr));

            // This is called to allow us to do validation.
            Func<HttpResponseMessage, bool> validateResp = respMessage =>
            {
                // We have chosen to not do validation. Our http classes
                // will do validation.
                return false;
            };

            try
            {
                var respdata = await FiniObjectGetRequest.Begin<FiniInstitutList>(
                    finiclient,
                    queryParams,
                    validateResp);
                return respdata.data ?? new FiniInstitutList();
            }
            catch (HttpRequestException e)
            {
                throw;
            }
            catch (JsonException jsonerr)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}


//public async Task<FiniInstitutList> Doit(string searchStr, HttpClient client)
//{
//    client.DefaultRequestHeaders.Accept.Clear();
//    client.DefaultRequestHeaders.Accept.Add(
//        new MediaTypeWithQualityHeaderValue("application/json"));
//    client.DefaultRequestHeaders.Add("K-Rednes", "93109ea8-ffac-4f13-8a11-a92e5b5250b5");

//    string url = QueryHelpers.AddQueryString(
//        "http://127.0.0.1:3003/api/institutions/search", "institution_search_name", searchStr);


//    // Http status_code of 200 and 404 are ok.
//    FiniInstitutList? data = null;
//    HttpStatusCode httpStatus = HttpStatusCode.InternalServerError;
//    try
//    {
//        // To deserialize json to object, get stream reader and deserialize
//        // to class.
//        var streamTask = client.GetStreamAsync(url);
//        data = await JsonSerializer.DeserializeAsync<FiniInstitutList>(await streamTask);
//        var ii = 0;
//    }
//    catch (HttpRequestException e)
//    {
//        httpStatus = _HandleHttpRequestException(e);
//        var ixx = 0;
//    }
//    catch (Exception e)
//    {
//        var excep = GetHttpStatus.HandleExceptionAsDefault(e);
//        if (excep != null) throw excep; else throw;
//    }

//    return data ?? new FiniInstitutList();
//}

//private HttpStatusCode _HandleHttpRequestException(HttpRequestException e)
//{
//    var statusInfo = GetHttpStatus.HandleHttpRequestException(e);
//    if (!statusInfo.httpStatusCode.HasValue)
//    {
//        Console.Out.WriteLine(statusInfo.message);
//        throw statusInfo.exception;
//    }
//    return statusInfo.httpStatusCode.Value;
//}

//    }