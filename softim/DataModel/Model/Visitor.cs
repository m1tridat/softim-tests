using System;
using System.ComponentModel.DataAnnotations.Schema;
using shop.Enums;

namespace DataModel.Model
{
    public class Visitor
    {
        [Index]
        public Guid Id { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int MoodId { get; set; }
        public Mood Mood { get; set; }
    }
}