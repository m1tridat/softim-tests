using System;
using Microsoft.EntityFrameworkCore;
using shop.Enums;

namespace DataModel.Model
{
    [Index("Id", "Age", "Sex", "Mood")]
    public class Visitor
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int Mood { get; set; }
    }
}