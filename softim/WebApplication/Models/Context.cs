using System.Data.Entity;

namespace WebApplication.Models
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}