using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practice;

namespace ownpractice.Controllers
{
    [Route("Movie")]
    public class MovieController : Controller
    {
        IHttpClientFactory _httpClientFactory;
        public MovieController(IHttpClientFactory factory)
        {
            _httpClientFactory = factory;
        }
        [HttpGet("Detail/{externalId}")]
        public async Task<IActionResult> Detail(string externalId)
        {// Создайте экземпляр HttpClient
            var httpClient = _httpClientFactory.CreateClient();

            // URL для API
            string anime = $"https://api.kinopoisk.dev/v1.3/movie?externalId.kpHD={externalId}";


            try
            {
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", "W2S5DKS-Z2YM9H5-JSJB4ZQ-G90JH0P");
                HttpResponseMessage response = await httpClient.GetAsync(anime);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                    Console.WriteLine("//////////////////////////");
                    // Десериализация JSON в объект вашего класса
                    Root root = JsonSerializer.Deserialize<Root>(jsonResponse);

                    // Используйте информацию о пагинации, которая уже приходит с сервиса
                    var movies = root.docs.ToList();

                    // Создайте объект ViewModel и передайте его в представление
                    var viewModel = new MovieViewModel
                    {
                        Movies = movies,
                        CurrentPage = 0,
                        TotalPages = 1,
                        ItemsPerPage = 1
                    };
                    return View(viewModel);
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