using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherWebApp
{
    public class MainClass
    {
        public SecondLevel Temperature { get; set; }

        public SecondLevel Main { get; set; }

        public SecondLevel Fact { get; set; }

        public SecondLevel Current { get; set; }

        public SecondLevel Minutely { get; set; }

        public SecondLevel Data { get; set; }

        static public int XAxis = 0;
    }
}