using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWindowsForms
{
    internal class SecondLevel
    {
        public ThirdLevel Metric { get; set; }

        public ThirdLevel Lower { get; set; }

        public double Temp { get; set; }

        public double Temp_c { get; set; }
    }
}
