using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Dtos;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        
        public ActionResult Index()
        {
            var visits = db.Visits
                .Include(x => x.Shop)
                .OrderByDescending(x => x.Date)
                .Take(100)
                .ToList();
            
            ViewBag.Visits = visits;
            
            return View();
        }

        public ActionResult StatisticsBySex()
        {
            var visits = db.Visits
                .Include(x => x.Shop)
                .ToList();

            var visitsBySex = visits
                .GroupBy(x => new {x.ShopId, x.Date.Date})
                .Select(x => new VisitsBySexDto
                {
                    ShopName = x.First().Shop.Name,
                    Date = x.Key.Date,
                    Address = x.First().Shop.Address,
                    Mans = x.Count(v => v.Sex == Sex.Man),
                    Womans = x.Count(v => v.Sex == Sex.Woman)
                })
                .OrderByDescending(x => x.Date)
                .ToList();
            
            return View(visitsBySex);
        }
        
        public ActionResult StatisticsByAge()
        {
            var visits = db.Visits
                .Include(x => x.Shop)
                .ToList();

            var visitsByAge = visits
                .GroupBy(x => new {x.ShopId, x.Date.Date})
                .Select(x => new VisitsByAgeDto
                {
                    ShopName = x.First().Shop.Name,
                    Date = x.Key.Date,
                    Address = x.First().Shop.Address,
                    Under20 = x.Count(v => v.Age <= 20),
                    Between20And40 = x.Count(v => v.Age >= 20 && v.Age <= 40),
                    Between40And60 = x.Count(v => v.Age >= 40 && v.Age <= 60),
                    Upper60 = x.Count(v => v.Age >= 60),
                })
                .OrderByDescending(x => x.Date)
                .ToList();
            
            return View(visitsByAge);
        }
        
        public ActionResult StatisticsByMood()
        {
            var visits = db.Visits
                .Include(x => x.Shop)
                .ToList();

            var visitsByMood = visits
                .GroupBy(x => new {x.ShopId, x.Date.Date})
                .Select(x => new VisitsByMoodDto
                {
                    ShopName = x.First().Shop.Name,
                    Date = x.Key.Date,
                    Address = x.First().Shop.Address,
                    Satisfied = x.Count(v => v.Mood > 7),
                    Sad = x.Count(v => v.Mood >= 4 && v.Mood <= 7),
                    Andgry = x.Count(v => v.Mood < 4),
                })
                .OrderByDescending(x => x.Date)
                .ToList();
            
            return View(visitsByMood);
        }
    }
}