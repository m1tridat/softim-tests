using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Shop
    {
        [Index]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}