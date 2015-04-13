using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ThreeSisters.Models;

namespace ThreeSisters.DAL {
    public class RealtyContext : DbContext {
        public DbSet<Listing> Listings { get; set; }
    }
}