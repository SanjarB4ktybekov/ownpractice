using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ownpractice.Controllers
{
    public class UserController : Controller
    {

        public UserController()
        {
        }

        public IActionResult GetLiked()
        {
            GeneralViewModelList generalViewModels = new();
            using (var db = new AppDbContext())
            {
                generalViewModels.generalViewModels = db.Movies.Where(m => m.userIndex == 1).Select(m => new GeneralViewModel{
                    Name = m.Name,
                    kpId = m.kpId
                }).ToList();
            }
            return View(generalViewModels);
        }

        public IActionResult GetDisliked()
        {
            GeneralViewModelList generalViewModels = new();
            using (var db = new AppDbContext())
            {
                generalViewModels.generalViewModels = db.Movies.Where(m => m.userIndex == 2).Select(m => new GeneralViewModel{
                    Name = m.Name,
                    kpId = m.kpId
                }).ToList();
            }
            return View("GetLiked", generalViewModels);
        }

        public IActionResult GetWatchAfter()
        {
            GeneralViewModelList generalViewModels = new();
            using (var db = new AppDbContext())
            {
                generalViewModels.generalViewModels = db.Movies.Where(m => m.userIndex == 3).Select(m => new GeneralViewModel{
                    Name = m.Name,
                    kpId = m.kpId
                }).ToList();
            }
            return View("GetLiked", generalViewModels);
        }
    }
}