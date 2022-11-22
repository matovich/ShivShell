using System;
using System.Net;

namespace Shell.DomainLayer.Exceptions
{

    [Serializable]
    public abstract class HttpStatusException : Exception
    {
        public HttpStatusException(HttpStatusCode statusCode) : base("(no message)")
        {
            StatusCode = statusCode;
        }

        public HttpStatusException(HttpStatusCode statusCode, string message) : base(message ?? "(no message)") 
        { 
           
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; init; }

        public virtual string ErrorTitle => "An error occurred";

        public override string ToString() => $"The status code [{StatusCode}] was received with the message {Message}.";
    }
}
