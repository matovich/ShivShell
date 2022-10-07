using System;

namespace Shell.DomainLayer.Exceptions.GatewayExceptions
{

    [Serializable]
    internal class GetWeatherAlertsFailedException : Exception
    {
        readonly System.Net.HttpStatusCode _statusCode;
        readonly string _message;
        readonly string _areaName;

        public GetWeatherAlertsFailedException(System.Net.HttpStatusCode statusCode, string message, string areaName)
        {
            _statusCode = statusCode;
            _message = message;
            _areaName = areaName;
        }

        public override string ToString()
        {
            return $"Status code [{_statusCode}] when searching for alert area {_areaName}{Environment.NewLine}{_message}";
        }
    }
}
