using System;
using System.Net;

namespace Shell.DomainLayer.Exceptions
{

    [Serializable]
    public abstract class HttpStatusException : Exception
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

        public virtual string ErrorTitle { get { return "An error occurred"; } }

        public override string ToString()
        {
            return $"The status code [{StatusCode}] was received with the message {Message}.";
        }
    }
}
