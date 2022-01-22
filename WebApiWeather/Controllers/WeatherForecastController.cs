using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWeather.Models;

namespace WebApiWeather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
       [HttpGet]
       public IActionResult GetWeather()
        {
            var list = new List<WeatherData>();
            for (int i = 0; i < 10; i++)
            {
                
                Random random = new Random();
                double maxTemperature = Math.Round(random.NextDouble() * 20 + 15, 1);
                WeatherData obj = new WeatherData()
                {
                    Date = DateTime.Now.AddDays(i),
                    MaxTemperature = maxTemperature,

                    MinTemperature = Math.Round(random.NextDouble() * (maxTemperature - 5), 1),

                    Pressure = random.Next(740, 780),

                    Humidity = random.Next(0,100),

                    WindPower = random.Next(0,5), 

                    WindDirection = GetWindDirection((WindDirectionEnum) random.Next(0, 8)),
                    Precipitation = GetPrecipitation((PrecipitationEnum) random.Next(0, 5))
                };

                list.Add(obj);
            }
            return Ok(list);
        }
       
        private string GetWindDirection(WindDirectionEnum value)
        {
            switch (value) {
                case WindDirectionEnum.North:
                    return "Север";
                case WindDirectionEnum.East:
                    return "Восток";
                case WindDirectionEnum.South:
                    return "Юг";
                case WindDirectionEnum.West:
                    return "Запад";
                case WindDirectionEnum.NorthWest:
                    return "Северо-запад";
                case WindDirectionEnum.NorthEast:
                    return "Северо-восток";
                case WindDirectionEnum.SouthWest:
                    return "Юго-запад";
                case WindDirectionEnum.SouthEast:
                    return "Юго-восток";

                default:
                    {
                        return "";
                    }


            }

           
        }
        private string GetPrecipitation(PrecipitationEnum value)
        {
            switch(value)
            {
                case PrecipitationEnum.Sunny:
                    return "Солнечно";
                case PrecipitationEnum.Cloudy:
                    return "Облачно";
                case PrecipitationEnum.LightRain:
                    return "Лёгкий дождь";
                case PrecipitationEnum.Rainfall:
                    return "Сильный дождь";
                case PrecipitationEnum.Thunderstorm:
                    return "Гроза";
                default:
                    {
                        return "";
                    }
            }
        }
    }
}
