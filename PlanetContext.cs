using System.Data.Entity;

namespace Planet
{
    class PlanetContext:DbContext
    {
        public PlanetContext()
            :base("DbConnection")
        { }
        public DbSet<Planet> Planet { get; set; }
    }
}
