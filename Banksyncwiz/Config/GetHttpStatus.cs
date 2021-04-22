using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Sockets;

using Banksyncwiz.Config;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;

namespace Banksyncwiz.Config
{
    public static class GetHttpStatus
    {
        public record StatusInfo
        {
            public HttpStatusCode? httpStatusCode { get; set; }
            public Exception exception { get; set; }
            public string? message { get; set; }

            public StatusInfo()
            {
                this.exception = new Exception("StatusInfo Default.");

            }
        }

        public static Exception? HandleExceptionAsDefault(Exception e)
        {
            if (e.InnerException != null)
            {
                return e.InnerException;
            }
            return null;
        }

        public static StatusInfo HandleHttpRequestException(HttpRequestException errHttp)
        {
            // If i have a status set. i'll use it.
            if (errHttp.StatusCode != null)
            {
                return new StatusInfo()
                {
                    httpStatusCode = errHttp.StatusCode,
                    exception = errHttp
                };
            }

            return errHttp.InnerException switch
            {
                System.IO.IOException errIo => HandleIoException(errIo),
                _ => new StatusInfo()
                    {
                        exception = errHttp,
                        message = errHttp.Message
                    },
            };
        }

        public static StatusInfo HandleIoException(System.IO.IOException errIo)
        {
            return errIo.InnerException switch
            {
                System.Net.Sockets.SocketException errSock => HandleSocketException(errSock),
                _ => new StatusInfo()
                    {
                        exception = errIo,
                        message = errIo.Message
                    },
            };
        }

        public static StatusInfo HandleSocketException(SocketException errSock)
        {
            return new StatusInfo()
            {
                exception = errSock,
                message = errSock.Message + "ErrorCode: " + errSock.ErrorCode + "."
            };
        }
    }
}
