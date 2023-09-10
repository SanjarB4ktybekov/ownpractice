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



        public async Task<IActionResult> MakeApiRequest(int page = 1, int pageSize = 10)
        {
            // Создайте экземпляр HttpClient
            var httpClient = _httpClientFactory.CreateClient();

            // URL для API
            string anime = $"https://api.kinopoisk.dev/v1.3/movie?type=anime&page={page}&limit={pageSize}";
            //ANR36PC-PW64GSK-GZX6240-48D23V9
            //W2S5DKS-Z2YM9H5-JSJB4ZQ-G90JH0P
            try
            {
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", "ANR36PC-PW64GSK-GZX6240-48D23V9");
                HttpResponseMessage response = await httpClient.GetAsync(anime);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                    Console.WriteLine("//////////////////////////");
                    // Десериализация JSON в объект вашего класса
                    Root root = JsonSerializer.Deserialize<Root>(jsonResponse);

                    // Используйте информацию о пагинации, которая уже приходит с сервиса
                    var totalPages = root.pages;

                    // Проверьте, чтобы текущая страница не превышала общее количество страниц
                    if (page < 1)
                    {
                        page = 1;
                    }
                    else if (page > totalPages)
                    {
                        page = (int)totalPages;
                    }

                    // Выполните пагинацию данных
                    var movies = root.docs.ToList();

                    // Создайте объект ViewModel и передайте его в представление
                    var viewModel = new MovieViewModel
                    {
                        Movies = movies,
                        CurrentPage = page,
                        TotalPages = (int)totalPages,
                        ItemsPerPage = pageSize
                    };

                    return View(viewModel);
                }
                else
                {
                    // Обработка ошибки
                    System.Console.WriteLine(response.StatusCode);
                    System.Console.WriteLine(response.RequestMessage);

                    return View("Error");
                }
            }
            catch (HttpRequestException e)
            {
                return Content($"Ошибка HTTP-запроса: {e.Message}");
            }
        }


    }
}