using Shell.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shell.DomainLayer.DataLayer.DataManagers
{
    internal class WeatherDataManager
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary> This would hit the database but is a simulation here. </summary>
        internal static IEnumerable<WeatherForcastDTO> GetWeather()
        {
            var rng = new Random();
            return Enumerable.Range(1, 7).Select(index =>
            {
                var tempC = rng.Next(-20, 55);
                return new WeatherForcastDTO(
                DateTime.Now.AddDays(index),
                tempC,
                ToFahrenheit(tempC),
                Summaries[rng.Next(Summaries.Length)]
                );
            })
            .ToArray();
        }

        private static int ToFahrenheit(int c) => 32 + (int)(c / 0.5556);
    }
}
