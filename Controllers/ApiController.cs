using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace practice.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MakeApiRequest()
        {
            // Создайте экземпляр HttpClient
            var httpClient = _httpClientFactory.CreateClient();

            // URL для API
            string apiUrl = "https://api.kinopoisk.dev/v1.3/movie/random";
            string anime = "https://api.kinopoisk.dev/v1.3/movie?type=anime&year=2017";
            try
            {
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", "W2S5DKS-Z2YM9H5-JSJB4ZQ-G90JH0P");
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                    Console.WriteLine("//////////////////////////");
                    // Десериализация JSON в объект вашего класса
                    Root responseObject = JsonSerializer.Deserialize<Root>(jsonResponse);
                    // Передача объекта в представление
                    return View(responseObject);
                }
                else
                {
                    // Обработка ошибки
                    System.Console.WriteLine(response.StatusCode);
                    System.Console.WriteLine(response.RequestMessage);

                    return View("ErrorView");
                }
            }
            catch (HttpRequestException e)
            {
                return Content($"Ошибка HTTP-запроса: {e.Message}");
            }
        }
    }
}