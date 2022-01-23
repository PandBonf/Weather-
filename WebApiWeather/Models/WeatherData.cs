using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiWeather.Models
{
    public class WeatherData
    {
        public string Date { get; set; }
        public double MaxTemperature { get; set; }
        public double MinTemperature { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }

        public int WindPower { get; set; }

        public string WindDirection { get; set; }

        public string Precipitation { get; set; }
    }
}
