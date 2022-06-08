using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherWebApp
{
    public class SecondLevel
    {
        public ThirdLevel Metric { get; set; }

        public ThirdLevel Lower { get; set; }

        public long Temp { get; set; }

        public float Temp_c { get; set; }
    }
}