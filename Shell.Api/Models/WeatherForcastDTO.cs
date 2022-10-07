
namespace Shell.Api.Models
{
    // RULE: Don't expose domain layer DTOs out on the API
    public record WeatherForcastDTO
    {
        public WeatherForcastDTO(DomainLayer.Models.WeatherForcastDTO forcast)
        {
            Date = forcast.Date;
            TemperatureC = forcast.TemperatureC;
            TemperatureF = forcast.TemperatureF;
            Summary = forcast.Summary;
        }

        public DateTime Date { get; }
        public int TemperatureC { get; }
        public int TemperatureF { get; }
        public string Summary { get; }
    }
}
