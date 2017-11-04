using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _04.Weather
{
    class Weather
    {
        public string CityName { get; set; }
        public double Temperature { get; set; }
        public string WeatherType { get; set; }

    }
    class Program
    {
        public static void Main()
        {

            string input = Console.ReadLine();
            var forecastList = new List<Weather>();

            while (input != "end")
            {
                var pattern = @"[A-Z]{2}([0-9]+\.[0-9]+)[A-Za-z]+(?=\|)";

                var regex = new Regex(pattern);

                var matches = regex.Matches(input);
                if (matches.Count == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                
                var cityName = "";
                var temperature = 0.0;
                var weatherType = "";
                foreach (Match item in matches)
                {
                    var text = item.ToString();
                    var city = text.Take(2).ToArray();
                    cityName = string.Join("", city);

                    var numberPattern = @"([0-9]+\.[0-9]+)";
                    var number = Regex.Match(input, numberPattern);
                    temperature = double.Parse(number.Value);
                    var type = text.Skip(2 + number.Length).ToArray();
                    weatherType = string.Join("", type);

                }
                bool doesExist = false;
                
                foreach (var f in forecastList)
                {
                    if (f.CityName == cityName)
                    {
                        doesExist = true;
                        f.Temperature = temperature;
                        f.WeatherType = weatherType;
                    }
                    
                }
                if (doesExist == false)
                {
                    var forecast = new Weather()
                    {
                        CityName = cityName,
                        Temperature = temperature,
                        WeatherType = weatherType
                    };
                    forecastList.Add(forecast);
                }
                

                input = Console.ReadLine();
            }

            foreach (var forecast in forecastList.OrderBy(c => c.Temperature))
            {
                Console.WriteLine($"{forecast.CityName} => {forecast.Temperature:f2} => {forecast.WeatherType}");
            }
        }
    }
}
