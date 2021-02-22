using System.Data.Entity;
using DataModel.Model;

namespace shop.DataModel
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}