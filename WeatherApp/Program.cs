using System.Net;
using Newtonsoft.Json;

namespace WeatherApp
{
    internal class Program
    {
        private static string path =
            "C:\\Users\\arda\\OneDrive\\Masaüstü\\Software Project\\Staj\\WeatherApp\\WeatherApp\\weather.csv";

        static void Main(string[] args)
        {
            StreamWriter writetext = new StreamWriter(path);
            Console.WriteLine("Enter the city: ");
            String citiesStr = Console.ReadLine();
            string[] cities = citiesStr.Split(" ");

            writetext.WriteLine("Date,Country,Name,Sunrise,Sunset,MinTemp_C,MaxTemp_C");

            foreach (string city in cities)
            {
                for (int j = 0; j > -3; j--)
                {
                    DateTime now = DateTime.Now;
                    now = now.AddDays(j);
                    string date = String.Format("{0:dd-MM-yyyy}", now);

                    Forecast forecast = new Forecast(date, city);
                    writeTxt(forecast,writetext);
                }
            }
            writetext.Close();
        }

        static void writeTxt(Forecast forecast, StreamWriter writetext)
        {
            if (!File.Exists(path))
            {
                var file = File.Create(path);

            }
            writetext.WriteLine(forecast.date + ", " +forecast.country + "," + forecast.name + "," + forecast.sunrise + "," + 
                                forecast.sunset + "," + forecast.mintemp_c + "," + forecast.maxtemp_c);
        }

        static DateTime convertDateTime(long sec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();

            return day;
        }
    }
}