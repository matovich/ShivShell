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

        public HttpStatusException(HttpStatusCode statusCode, string message) : base(message) 
        { 
            StatusCode = statusCode;
        }


        public HttpStatusCode StatusCode { get; init; }
    }
}
