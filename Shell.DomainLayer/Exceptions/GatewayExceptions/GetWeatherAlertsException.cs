using System;
using System.Net;

namespace Shell.DomainLayer.Exceptions.GatewayExceptions
{

    [Serializable]
    public class GetWeatherAlertsException : HttpStatusException
    {
        readonly string _message;
        readonly string _areaName;

        public GetWeatherAlertsException(HttpStatusCode statusCode, string message, string areaName) : base(statusCode)
        {
            _message = message;
            _areaName = areaName;
        }

        public override string ToString()
        {
            return $"Status code [{StatusCode}] when searching for alert area {_areaName}{Environment.NewLine}{_message}";
        }
    }
}
