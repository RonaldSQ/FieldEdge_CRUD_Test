using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FieldEdge_CRUD_Test
{
    public class Weather
    {
        public static HttpClient WeatherAPI { get; set; }

        public static void StartWeather()
        {
            WeatherAPI = new HttpClient();
            WeatherAPI.BaseAddress = new Uri("https://api4all.azurewebsites.net");
            WeatherAPI.DefaultRequestHeaders.Accept.Clear();
            WeatherAPI.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("ApplicationException/json"));
            
        }
    }
}