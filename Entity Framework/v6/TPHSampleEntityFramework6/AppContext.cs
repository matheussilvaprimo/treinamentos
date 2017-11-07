using System.Data.Entity;

namespace TPHSampleEntityFramework6
{
    public class AppContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        public AppContext() { }
        public AppContext(string conn) : base(conn)
        {
            Database.SetInitializer(new MyCustomDBInitializer());

            if (!Database.Exists())
            {
                Database.Initialize(true);
            }
        }
    }
}
