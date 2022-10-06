using System;

namespace Shell.DomainLayer.Models
{
    public record WeatherForcastDTO(DateTime Date, int TemperatureC, int TemperatureF, string Summary);
}
