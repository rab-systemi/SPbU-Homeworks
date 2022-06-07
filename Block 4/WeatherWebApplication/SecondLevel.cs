namespace WeatherWebApplication
{
    public class SecondLevel
    {
        public ThirdLevel Metric { get; set; }

        public ThirdLevel Lower { get; set; }

        public long Temp { get; set; }

        public float Temp_c { get; set; }

        public List<List<KeyValuePair<string, string>>> Values { get; set; }
    }
}
