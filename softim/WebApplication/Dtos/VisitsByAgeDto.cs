using System;

namespace WebApplication.Dtos
{
    public class VisitsByAgeDto
    {
        public string ShopName  { get; set; }
        public DateTime Date  { get; set; }
        public string Address { get; set; }
        public int Under20 { get; set; }
        public int Between20And40 { get; set; }
        public int Between40And60 { get; set; }
        public int Upper60 { get; set; }
    }
}