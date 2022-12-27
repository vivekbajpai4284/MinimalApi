using MinimalApi.Contracts;
using MinimalApi.Model;
using MinimalApi.Repository;
using MinimalApi.SecretSauce;

namespace MinimalApi.EndpointDefinitions
{
    public class WeatherforecastDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            var summaries = new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };

            app.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateTime.Now.AddDays(index),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray();
                return forecast;
            });
              
        }
        public void DefineServices(IServiceCollection services)
        {
            services.AddTransient<IWeatherforcastRepository, WeatherforcastRepository>();
        }
    }

}
