using Dapr.Client;

namespace MyFirtsAspireAppWithDapr.Web;

public class WeatherApiClient //(DaprClient daprClient)
{
    public WeatherApiClient(DaprClient daprClient) => this.daprClient = daprClient;

    private readonly DaprClient daprClient;

    public async Task<WeatherForecast[]> GetWeatherAsync()
    {
        // var test = await daprClient.InvokeMethodAsync<string>(HttpMethod.Post, "api", "test");

        return await daprClient.InvokeMethodAsync<WeatherForecast[]>(HttpMethod.Get, "api", "weatherforecast");
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
