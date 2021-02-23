using System;
using System.Linq;
using DataModel;
using Microsoft.EntityFrameworkCore;
using shop.Enums;

namespace shop
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var visits = context.Visits
                    .Include(x => x.Shop)
                    .Include(x => x.Visitor)
                    .Include(x => x.Visitor.Mood)
                    .GroupBy(x => new {x.ShopId, x.Date})
                    .ToList();

                Console.WriteLine("By visitors sex");
                Console.WriteLine("Shop | Address | Day | Mans | Womans");
                var visitsByShopAndDay = visits
                    .Select(x => new
                    {
                        x.Key,
                        ShopName = x.First().Shop.Name,
                        x.First().Shop.Address,
                        Mans = x.Count(v => v.Visitor.Sex == Sex.Man),
                        Womans = x.Count(v => v.Visitor.Sex == Sex.Woman)
                    })
                    .ToList();

                foreach (var v in visitsByShopAndDay)
                {
                    Console.WriteLine($"{v.ShopName} {v.Address} {v.Key.Date.ToShortDateString()} {v.Mans} {v.Womans}");
                }
                
                Console.WriteLine("By visitors age");
                Console.WriteLine("Shop | Address | Day | >20 | 20:40 | 40:60 | 60<");
                var visitsByAge = visits
                    .Select(x => new
                    {
                        x.Key,
                        ShopName = x.First().Shop.Name,
                        x.First().Shop.Address,
                        Under20 = x.Count(v => v.Visitor.Age <= 20),
                        Between20and40 = x.Count(v => v.Visitor.Age >= 20 && v.Visitor.Age <= 40),
                        Between40and60 = x.Count(v => v.Visitor.Age >= 40 && v.Visitor.Age <= 60),
                        Upper60 = x.Count(v => v.Visitor.Age >= 60),
                    })
                    .ToList();

                foreach (var v in visitsByAge)
                {
                    Console.WriteLine($"{v.ShopName} {v.Address} {v.Key.Date.ToShortDateString()} {v.Under20} {v.Between20and40} {v.Between40and60} {v.Upper60}");
                }
                
                Console.WriteLine("By visitors mood");
                Console.WriteLine("Shop | Address | Day | Satisfied | Sad | Angry");
                var visitsByMood = visits
                    .Select(x => new
                    {
                        x.Key,
                        ShopName = x.First().Shop.Name,
                        x.First().Shop.Address,
                        Satisfied = x.Count(v => v.Visitor.Mood > 7),
                        Sad = x.Count(v => v.Visitor.Mood >= 4 && v.Visitor.Mood <= 7),
                        Andgry = x.Count(v => v.Visitor.Mood < 4),
                    })
                    .ToList();

                foreach (var v in visitsByMood)
                {
                    Console.WriteLine($"{v.ShopName} {v.Address} {v.Key.Date.ToShortDateString()} {v.Satisfied} {v.Sad} {v.Andgry}");
                }
            }
            
            Console.ReadLine();
        }
    }
}