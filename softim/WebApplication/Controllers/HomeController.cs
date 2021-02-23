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
        
        public ActionResult Index(int? shopId, DateTime? date)
        {
            var shops = db.Shops
                .OrderBy(x => x.Name)
                .ToList();
            
            var visits = db.Visits
                .Include(x => x.Shop)
                .Where(x => shopId == null || x.ShopId == shopId)
                .Where(x => date == null || DbFunctions.TruncateTime(x.Date) == date)
                .OrderByDescending(x => x.Date)
                .Take(100)
                .ToList();
            
            ViewBag.Visits = visits;
            ViewBag.Shops = new SelectList(shops,"Id","Name");
            
            return View();
        }

        public ActionResult StatisticsBySex(int? shopId, DateTime? date)
        {
            var shops = db.Shops
                .OrderBy(x => x.Name)
                .ToList();
            
            var visits = db.Visits
                .Include(x => x.Shop)
                .Where(x => shopId == null || x.ShopId == shopId)
                .Where(x => date == null || DbFunctions.TruncateTime(x.Date) == date)
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
            
            
            ViewBag.Shops = new SelectList(shops,"Id","Name");
            
            return View(visitsBySex);
        }
        
        public ActionResult StatisticsByAge(int? shopId, DateTime? date)
        {
            var shops = db.Shops
                .OrderBy(x => x.Name)
                .ToList();
            
            var visits = db.Visits
                .Include(x => x.Shop)
                .Where(x => shopId == null || x.ShopId == shopId)
                .Where(x => date == null || DbFunctions.TruncateTime(x.Date) == date)
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
            
            ViewBag.Shops = new SelectList(shops,"Id","Name");
            
            return View(visitsByAge);
        }
        
        public ActionResult StatisticsByMood(int? shopId, DateTime? date)
        {
            var shops = db.Shops
                .OrderBy(x => x.Name)
                .ToList();
            
            var visits = db.Visits
                .Include(x => x.Shop)
                .Where(x => shopId == null || x.ShopId == shopId)
                .Where(x => date == null || DbFunctions.TruncateTime(x.Date) == date)
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
            
            
            ViewBag.Shops = new SelectList(shops,"Id","Name");
            
            return View(visitsByMood);
        }
    }
}