using System.Data.Entity;

namespace TPCSampleEntityFramework
{
    public class AppContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        public AppContext() { }

        public AppContext(string connString)
            : base(connString)
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("Alunos");
            });

            modelBuilder.Entity<Professor>().Map(x =>
            {
                x.MapInheritedProperties();
                x.ToTable("Professores");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
