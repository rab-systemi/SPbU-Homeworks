namespace WeatherWindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Request<MainClass> request = new();

            const string apiKeyAccuWeather = "gJbOV5lzq1nHH8XBz36EXf2PIkXwUAZc";

            const string urlAccuWeather = $"http://dataservice.accuweather.com/currentconditions/v1/295212?apikey={apiKeyAccuWeather}";

            const string apiKeyOpenWeatherMap = "fe517792ca36f2337ce7b93b00fefa31";

            const string urlOpenWeatherMap = $"http://api.openweathermap.org/data/2.5/weather?id=498817&units=metric&appid={apiKeyOpenWeatherMap}";

            const string apiKeyWeatherApi = "7ec67756c3694f42a9203335220706";

            const string urlWeatherApi = $"http://api.weatherapi.com/v1/current.json?key={apiKeyWeatherApi}&q=Saint&aqi=yes";

            var mainClassAccuweather = request.GetTemperature(urlAccuWeather);

            var mainClassWeatherApi = request.GetTemperatureWeatherApi(urlWeatherApi);

            var mainClassOpenWeatherMap = request.GetTemperatureWeatherApi(urlOpenWeatherMap);

            string outputAccuweather = mainClassAccuweather[0].Temperature.Metric.Value;

            string outputOpenWeatherMap = mainClassOpenWeatherMap.Main.Temp.ToString();

            string outputWeatherApi = mainClassWeatherApi.Current.Temp_c.ToString();

            List<double> numbersToDraw = new();

            double numberToAdd = (Convert.ToDouble(outputOpenWeatherMap) + Convert.ToDouble(outputWeatherApi)) / 2;
            numbersToDraw.Add(numberToAdd);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}