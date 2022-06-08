using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeatherWebApp
{
    public partial class Weather : System.Web.UI.Page
    {
        public int XAxis = 0;

        public List<double> data = new List<double>();

        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayChart()
        {
            Request<MainClass> request = new Request<MainClass>();

            const string apiKeyAccuWeather = "gJbOV5lzq1nHH8XBz36EXf2PIkXwUAZc";

            string urlAccuWeather = $"http://dataservice.accuweather.com/currentconditions/v1/295212?apikey={apiKeyAccuWeather}";

            const string apiKeyOpenWeatherMap = "fe517792ca36f2337ce7b93b00fefa31";

            string urlOpenWeatherMap = $"http://api.openweathermap.org/data/2.5/weather?id=498817&units=metric&appid={apiKeyOpenWeatherMap}";

            string apiKeyWeatherApi = "7ec67756c3694f42a9203335220706";

            string urlWeatherApi = $"http://api.weatherapi.com/v1/current.json?key={apiKeyWeatherApi}&q=Saint&aqi=yes";


            //var mainClassAccuweather = request.GetTemperature(urlAccuWeather);

            var mainClassWeatherApi = request.GetTemperatureWeatherApi(urlWeatherApi);

            var mainClassOpenWeatherMap = request.GetTemperatureWeatherApi(urlOpenWeatherMap);


            //string outputAccuweather = mainClassAccuweather[0].Temperature.Metric.Value;

            string outputOpenWeatherMap = mainClassOpenWeatherMap.Main.Temp.ToString();

            string outputWeatherApi = mainClassWeatherApi.Current.Temp_c.ToString();

            double outputY = (Convert.ToDouble(outputOpenWeatherMap) + Convert.ToDouble(outputWeatherApi)) / 2;

            data.Add(outputY);

            string outputData = "0";

            string xAxis = "0";

            for (int i = 0; i < data.Count; i++)
            {
                outputData += $", {data[i]}";
                xAxis += $", {i + 1}";
            }


            string chart = "";

            chart = "<canvas id=\"line-chart\" width=\"100%\" heigh=\"400\"><canvas>";
            chart += "<script>";
            chart += "new Chart(document.getElementById(\"line-chart\"), {type: 'line', data: {";
            chart += $"labels: [{xAxis}]";
            chart += ",datasets: [{data: [";

            chart += outputData;

            chart += "], label: \"Weather\", borderColor: \"#3e95cd\",fill: false}";
            chart += "]},options: { title: { display: true,text: 'Your chart title'} }";
            chart += "});";
            chart += "</script>";

            //MyChart.Text = chart;
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
            
        }

        private void DisplayData()
        {
            Request<MainClass> request = new Request<MainClass>();
            const string apiKeyAccuWeather = "gJbOV5lzq1nHH8XBz36EXf2PIkXwUAZc";

            string urlAccuWeather = $"http://dataservice.accuweather.com/currentconditions/v1/295212?apikey={apiKeyAccuWeather}";

            const string apiKeyOpenWeatherMap = "fe517792ca36f2337ce7b93b00fefa31";

            string urlOpenWeatherMap = $"http://api.openweathermap.org/data/2.5/weather?id=498817&units=metric&appid={apiKeyOpenWeatherMap}";

            const string apiKeyWeatherApi = "7ec67756c3694f42a9203335220706";

            string urlWeatherApi = $"http://api.weatherapi.com/v1/current.json?key={apiKeyWeatherApi}&q=Saint&aqi=yes";

            //var mainClassAccuweather = request.GetTemperature(urlAccuWeather);

            var mainClassWeatherApi = request.GetTemperatureWeatherApi(urlWeatherApi);

            var mainClassOpenWeatherMap = request.GetTemperatureWeatherApi(urlOpenWeatherMap);

            //string outputAccuweather = mainClassAccuweather[0].Temperature.Metric.Value;

            string outputOpenWeatherMap = mainClassOpenWeatherMap.Main.Temp.ToString();

            string outputWeatherApi = mainClassWeatherApi.Current.Temp_c.ToString();

            double outputY = (Convert.ToDouble(outputOpenWeatherMap) + Convert.ToDouble(outputWeatherApi)) / 2;

            Chart1.Series[0].Points.AddXY(MainClass.XAxis, outputY);
            MainClass.XAxis++;
        }
    }
}