using System;
using System.Data.Entity;
using System.Linq;
using shop.DataModel;
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
                    .ToList();

                var visitsByShopAndDay = visits
                    .GroupBy(x => new {x.ShopId, x.Date})
                    .Select(x => new
                    {
                        x.Key,
                        Mans = x.Count(v => v.Visitor.Sex == Sex.Man),
                        Womans = x.Count(v => v.Visitor.Sex == Sex.Woman)
                    })
                    .ToList();

                var visitsByAge = visits
                    .GroupBy(x => new {x.ShopId, x.Date})
                    .Select(x => new
                    {
                        x.Key,
                        Under20 = x.Count(v => v.Visitor.Age <= 20),
                        Between20and40 = x.Count(v => v.Visitor.Age >= 20 && v.Visitor.Age <= 40),
                        Between40and60 = x.Count(v => v.Visitor.Age >= 40 && v.Visitor.Age <= 60),
                        Upper60 = x.Count(v => v.Visitor.Age >= 60),
                    })
                    .ToList();

                var visitsByMood = visits
                    .GroupBy(x => new
                    {
                        x.ShopId,
                        x.Date,
                        x.Visitor.MoodId
                    })
                    .Select(x => new
                    {
                        x.Key,
                        Amount = x.Count(),
                    });
            }
            
            Console.ReadLine();
        }
    }
}