using System;
using System.Net;

namespace Shell.DomainLayer.Exceptions
{

    [Serializable]
    public class HttpStatusException : Exception
    {
        public HttpStatusException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }


        public HttpStatusCode StatusCode { get; init; }
    }
}
