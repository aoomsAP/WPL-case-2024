using FCentricProspections.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Net;

namespace FCentricProspections.Server.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Prospection> Prospection { get; set; }
    }

}
