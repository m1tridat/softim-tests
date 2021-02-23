using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebApplication.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<Context>
    {
        private readonly Random _gen = new Random();
        
        protected override void Seed(Context db)
        {
            var shops = new List<Shop>();
            for (int i = 1; i < 10; i++)
            {
                shops.Add(new Shop
                {
                    Name = $"Shop #{i}",
                    Address = $"Address #{i}"
                });
            }
            db.Shops.AddRange(shops);

            var visits = new List<Visit>();
            
            for (int i = 0; i < 100000; i++)
            {
                visits.Add(new Visit
                {
                    Age = _gen.Next(1, 80),
                    Date = RandomDay(),
                    Mood = _gen.Next(1, 10),
                    Sex = GetRandomSex(),
                    Shop = shops[_gen.Next(0, 9)]
                });
            }

            db.Visits.AddRange(visits);
            
            db.SaveChanges();
            
            base.Seed(db);
        }
        
        DateTime RandomDay()
        {
            int hour = _gen.Next(0, 24);
            int minute = _gen.Next(0, 59);
            int second = _gen.Next(0, 59);
            DateTime start = new DateTime(2021, 1, 1, hour, minute, second);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_gen.Next(range));
        }

        Sex GetRandomSex()
        {
            Array values = Enum.GetValues(typeof(Sex));
            var sex = (Sex)values.GetValue(_gen.Next(values.Length));
            return sex;
        } 
    }
}