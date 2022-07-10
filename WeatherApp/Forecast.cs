using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    internal class Forecast
    {
        private string apiKey = "630fa2ed3b5c42d8875165219220907";
        private string city;
        private string requestedDate = null;

        public string country = null;
        public string region = null;
        public string name = null;

        public string date;

        public double mintemp_c;
        public double maxtemp_c;

        public string sunrise = null;
        public string sunset = null;

        public Forecast(string date,string city)
        {
            this.city = city;
            this.requestedDate = date;

            getWeather();
        }

        void getWeather()
        {
            using (WebClient web = new WebClient())
            {

                string url = string.Format("http://api.weatherapi.com/v1/history.json?key={0}&q={1}&dt={2}", apiKey, city, requestedDate);

                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                country = Info.location.country;
                region = Info.location.region;
                name = Info.location.name;

                date = Info.forecast.forecastday[0].date;

                mintemp_c = Info.forecast.forecastday[0].day.mintemp_c;
                maxtemp_c = Info.forecast.forecastday[0].day.maxtemp_c;

                sunrise = Info.forecast.forecastday[0].astro.sunrise;
                sunset = Info.forecast.forecastday[0].astro.sunset;
            }
        }

        DateTime convertDateTime(long sec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();

            return day;
        }
    }
}
