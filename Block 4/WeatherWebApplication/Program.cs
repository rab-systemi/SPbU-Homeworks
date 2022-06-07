using System;
using System.Net;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace WeatherWebApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            Request<MainClass> request = new();

            const string apiKeyAccuWeather = "gJbOV5lzq1nHH8XBz36EXf2PIkXwUAZc";

            const string urlAccuWeather = $"http://dataservice.accuweather.com/currentconditions/v1/295212?apikey={apiKeyAccuWeather}";

            const string apiKeyOpenWeatherMap = "fe517792ca36f2337ce7b93b00fefa31";

            const string urlOpenWeatherMap = $"http://api.openweathermap.org/data/2.5/weather?id=498817&units=metric&appid={apiKeyOpenWeatherMap}";

            //const string httpStatusCode = $"https://api.openweathermap.org/data/2.5/onecall?lat=59.894444&lon=30.264168&appid={apiKeyOpenWeatherMap}";

            const string apiKeyYandex = "4125526b-f83f-40e0-9993-98314966be80";

            const string urlYandex = $"https://api.weather.yandex.ru/v2/informers?lat=59.938951&lon=30.315635";

            const string urlGismeteo = $"https://api.gismeteo.net/v2/search/cities/?latitude=54.35&longitude=52.52";

            const string apiKeyWeatherApi = "7ec67756c3694f42a9203335220706";

            const string urlWeatherApi = $"http://api.weatherapi.com/v1/current.json?key={apiKeyWeatherApi}&q=Saint&aqi=yes";

            const string apiKeyWeatherBit = "d96ffcf2bfaa4d7c92861fafc6bbf14a";

            const string urlWeatherBit = $"https://api.weatherbit.io/v2.0/current?lat=59.9342&lon=30.3350&key={apiKeyWeatherBit}&include=minutely";

            //var mainClassAccuweather = request.GetTemperature(urlAccuWeather);

            //var mainClassWeatherApi = request.GetTemperatureWeatherApi(urlWeatherApi);

            var mainClassOpenWeatherMap = request.GetTemperatureWeatherApi(urlOpenWeatherMap);

            //var mainClassWeatherBit = request.GetTemperatureWeatherBit(urlWeatherBit);

            //string outputAccuweather = mainClassAccuweather[0].Temperature.Metric.Value;

            string outputOpenWeatherMap = mainClassOpenWeatherMap.Main.Temp.ToString();

            //string outputWeatherApi = mainClassWeatherApi.Current.Temp_c.ToString();

            //string outputWeatherBit = mainClassWeatherBit.Data.Values[0][0].Value.ToString();

            app.MapGet("/", () => outputOpenWeatherMap);

            app.Run();
        }
    }
}