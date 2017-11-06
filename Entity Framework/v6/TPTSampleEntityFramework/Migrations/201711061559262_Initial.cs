namespace TPTSampleEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Cpf = c.Long(nullable: false),
                        Nome = c.String(),
                        SobreNome = c.String(),
                        Endereco = c.String(),
                        Matricula = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        CapacidadeAlunos = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DisciplinaAlunoes",
                c => new
                    {
                        Disciplina_Id = c.Guid(nullable: false),
                        Aluno_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disciplina_Id, t.Aluno_Id })
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_Id, cascadeDelete: true)
                .ForeignKey("dbo.Alunos", t => t.Aluno_Id, cascadeDelete: true)
                .Index(t => t.Disciplina_Id)
                .Index(t => t.Aluno_Id);
            
            CreateTable(
                "dbo.ProfessorDisciplinas",
                c => new
                    {
                        Professor_Id = c.Guid(nullable: false),
                        Disciplina_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Professor_Id, t.Disciplina_Id })
                .ForeignKey("dbo.Professores", t => t.Professor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_Id, cascadeDelete: true)
                .Index(t => t.Professor_Id)
                .Index(t => t.Disciplina_Id);
            
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DataIngresso = c.DateTime(nullable: false),
                        SemestreAtual = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Professores",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DataContratacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoas", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Professores", "Id", "dbo.Pessoas");
            DropForeignKey("dbo.Alunos", "Id", "dbo.Pessoas");
            DropForeignKey("dbo.ProfessorDisciplinas", "Disciplina_Id", "dbo.Disciplinas");
            DropForeignKey("dbo.ProfessorDisciplinas", "Professor_Id", "dbo.Professores");
            DropForeignKey("dbo.DisciplinaAlunoes", "Aluno_Id", "dbo.Alunos");
            DropForeignKey("dbo.DisciplinaAlunoes", "Disciplina_Id", "dbo.Disciplinas");
            DropIndex("dbo.Professores", new[] { "Id" });
            DropIndex("dbo.Alunos", new[] { "Id" });
            DropIndex("dbo.ProfessorDisciplinas", new[] { "Disciplina_Id" });
            DropIndex("dbo.ProfessorDisciplinas", new[] { "Professor_Id" });
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Aluno_Id" });
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Disciplina_Id" });
            DropTable("dbo.Professores");
            DropTable("dbo.Alunos");
            DropTable("dbo.ProfessorDisciplinas");
            DropTable("dbo.DisciplinaAlunoes");
            DropTable("dbo.Disciplinas");
            DropTable("dbo.Pessoas");
        }
    }
}
