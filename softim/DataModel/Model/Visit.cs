using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Model
{
    public class Visit
    {
        public int Id { get; set; }
        [Index]
        public DateTime Date { get; set; }
        [Index]
        public Guid VisitorId { get; set; }
        public Visitor Visitor { get; set; }
        [Index]
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}