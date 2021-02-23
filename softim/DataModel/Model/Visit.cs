using System;
using Microsoft.EntityFrameworkCore;

namespace DataModel.Model
{
    [Index("Date", "VisitorId", "ShopId")]
    public class Visit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Guid VisitorId { get; set; }
        public Visitor Visitor { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}