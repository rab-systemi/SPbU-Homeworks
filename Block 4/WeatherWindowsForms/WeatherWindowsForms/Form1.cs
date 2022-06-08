using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherWindowsForms
{
    
    public partial class Form1 : Form
    {
        public int i = 0;
        public Form1()
        {
            InitializeComponent();
        }



        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
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
            chart1.Series[0].Points.AddXY(i, outputY);
            i++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
