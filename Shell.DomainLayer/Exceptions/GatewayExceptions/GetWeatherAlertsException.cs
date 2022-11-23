using System;
using System.Net;

namespace Shell.DomainLayer.Exceptions.GatewayExceptions
{

    [Serializable]
    public class GetWeatherAlertsException : HttpStatusException
    {
        readonly string _areaName;

        public GetWeatherAlertsException(HttpStatusCode statusCode, string message, string areaName) : base(statusCode, message)
        {
            _areaName = areaName;
        }

        public override string ErrorTitle => "An exception occurred while getting weather alerts." ;

        public override string ToString() => $"Status code [{StatusCode}] when searching for alert area {_areaName}. Message: {Message}";
    }
}
