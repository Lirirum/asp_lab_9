using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication11.Models;


namespace WebApplication11.Components
{
    public class WeatherViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string region)
        {   
 
            using (var httpClient = new HttpClient())
            {
                var apiKey = "e0d0a24dae1950587ef4e1e600f0008f";
                var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={region}&appid={apiKey}&units=metric";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    dynamic jsonObject = JsonConvert.DeserializeObject(content);

                    WeatherData weatherData = new WeatherData
                    {
                        City = jsonObject.name,
                        Temperature = jsonObject.main.temp,
                        Weather = jsonObject.weather[0].main,  
                        WeatherDescription = jsonObject.weather[0].description,
                        Humidity = jsonObject.main.humidity,
                        WindSpeed = jsonObject.wind.speed,


                    };
                    return View("../Views/Weather.cshtml",weatherData);
                }
            }

            return Content("Помилка отримання погоди");
        }

    }
}
