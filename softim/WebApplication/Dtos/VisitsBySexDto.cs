using System;

namespace WebApplication.Dtos
{
    public class VisitsBySexDto
    {
        public string ShopName  { get; set; }
        public DateTime Date  { get; set; }
        public string Address  { get; set; }
        public int Mans  { get; set; }
        public int Womans { get; set; }
    }
}