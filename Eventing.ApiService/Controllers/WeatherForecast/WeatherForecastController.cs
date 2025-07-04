using Eventing.ApiService.Controllers.WeatherForecast.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Eventing.ApiService.Controllers.WeatherForecast;

public class WeatherForecastController : ApiBaseController
{
    private readonly string[] _summaries =
        ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    [HttpGet]
    [EndpointName("GetWeatherForecast")] // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/include-metadata
    public WeatherForecastResponseDto[] GetAll()
        => Enumerable.Range(1, 5).Select(index =>
                new WeatherForecastResponseDto
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    _summaries[Random.Shared.Next(_summaries.Length)]
                ))
            .ToArray();
}