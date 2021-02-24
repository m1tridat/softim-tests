using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Shop
    {
        [Index]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
        public virtual ICollection<Visit> Visits { get; set; }
    }
}