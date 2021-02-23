using System;

namespace WebApplication.Dtos
{
    public class VisitsByMoodDto
    {
        public string ShopName  { get; set; }
        public DateTime Date  { get; set; }
        public string Address { get; set; }
        public int Satisfied { get; set; }
        public int Sad { get; set; }
        public int Andgry  { get; set; }
    }
}