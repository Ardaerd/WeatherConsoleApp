using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class WeatherInfo
    {
        public class location
        {
            public string country { get; set; }
            public string region { get; set; }
            public string name { get; set; }
        }

        public class forecast
        {
            public List<forecastday> forecastday { get; set; }
        }

        public class day
        {
            public double maxtemp_c { get; set; }
            public double mintemp_c { get; set; }

        }

        public class astro
        {
            public string sunrise { get; set; }
            public string sunset { get; set; }

        }

        public class forecastday
        {
            public string date { get; set; }

            public day day { get; set; }

            public astro astro { get; set; }
        }

        public class root
        {
            public location location { get; set; }
            public forecast forecast { get; set; }


        }
    }
}
