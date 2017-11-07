using System.Data.Entity;

namespace TPHSampleEntityFramework6
{
    public class AppContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public AppContext(string conn) : base(conn)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppContext>());
        }
    }
}
