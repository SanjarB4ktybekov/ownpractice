using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ownpractice.Entities;
using practice;

namespace ownpractice.Controllers
{
    public class Recomendation : Controller
    {
        private readonly ILogger<Recomendation> _logger;

        public Recomendation(ILogger<Recomendation> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToLiked(string id)
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}