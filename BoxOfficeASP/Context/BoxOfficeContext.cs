using BoxOfficeASP.Models;
using System.Data.Entity;

namespace BoxOfficeASP.Context
{
    public class BoxOfficeContext : DbContext
    {
        public BoxOfficeContext() : base("DbConnection") { }

        public DbSet<Seance> Seances { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}