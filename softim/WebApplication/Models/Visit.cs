using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Visit
    {
        [Index]
        [Key]
        public int Id { get; set; }
        [Index]
        public DateTime Date { get; set; }
        [Index]
        public int ShopId { get; set; }
        [Index]
        public int Age { get; set; }
        [Index]
        public Sex Sex { get; set; }
        [Index]
        public int Mood { get; set; }
        
        
        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }
    }
}