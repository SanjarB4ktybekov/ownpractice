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

        public IActionResult AddToLiked(string id, string name )
        {
            System.Console.WriteLine($"name = {name}");
            using (var db = new AppDbContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.kpId == id);
                if (movie == null)
                {
                    System.Console.WriteLine("Такого кина нет");
                    db.Movies.Add(new _Movie { kpId = id, Name = name });
                    db.SaveChanges();
                } else
                {
                    System.Console.WriteLine("Такого кина есть");
                }
                movie.userIndex = 1;
                movie.Name = name;
                db.Movies.Update(movie);
                db.SaveChanges();
            }
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult SetDefault(string id, string name)
        {
            using (var db = new AppDbContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.kpId == id);
                if (movie == null)
                {
                    System.Console.WriteLine("Такого кина нет");
                    db.Movies.Add(new _Movie { kpId = id, Name = name });
                    db.SaveChanges();
                } else
                {
                    System.Console.WriteLine("Такого кина есть");
                }
                movie.userIndex = 0;
                movie.Name = name;
                db.Movies.Update(movie);
                db.SaveChanges();
            }
            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult AddToDisliked(string id, string name)
        {
            using (var db = new AppDbContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.kpId == id);
                if (movie == null)
                {
                    System.Console.WriteLine("Такого кина нет");
                    db.Movies.Add(new _Movie { kpId = id, Name = name });
                    db.SaveChanges();
                } else
                {
                    System.Console.WriteLine("Такого кина есть");
                }
                movie.userIndex = 2;
                movie.Name = name;
                db.Movies.Update(movie);
                db.SaveChanges();

            }
            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult AddToFutureList(string id, string name)
        {
            using (var db = new AppDbContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.kpId == id);
                if (movie == null)
                {
                    System.Console.WriteLine("Такого кина нет");
                    db.Movies.Add(new _Movie { kpId = id, Name = name });
                    db.SaveChanges();
                } else
                {
                    System.Console.WriteLine("Такого кина есть");
                }
                movie.userIndex = 3;
                movie.Name = name;
                db.Movies.Update(movie);
                db.SaveChanges();

            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}