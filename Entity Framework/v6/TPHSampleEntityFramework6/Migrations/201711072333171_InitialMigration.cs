namespace TPHSampleEntityFramework6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Cpf = c.Long(nullable: false),
                        Nome = c.String(),
                        SobreNome = c.String(),
                        Endereco = c.String(),
                        Matricula = c.Long(nullable: false),
                        DataIngresso = c.DateTime(),
                        SemestreAtual = c.Long(),
                        DataContratacao = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AlunoDisciplinas",
                c => new
                    {
                        Aluno_Id = c.Guid(nullable: false),
                        Disciplina_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Aluno_Id, t.Disciplina_Id })
                .ForeignKey("dbo.Pessoas", t => t.Aluno_Id, cascadeDelete: true)
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_Id, cascadeDelete: true)
                .Index(t => t.Aluno_Id)
                .Index(t => t.Disciplina_Id);
            
            CreateTable(
                "dbo.ProfessorDisciplinas",
                c => new
                    {
                        Professor_Id = c.Guid(nullable: false),
                        Disciplina_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Professor_Id, t.Disciplina_Id })
                .ForeignKey("dbo.Pessoas", t => t.Professor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_Id, cascadeDelete: true)
                .Index(t => t.Professor_Id)
                .Index(t => t.Disciplina_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfessorDisciplinas", "Disciplina_Id", "dbo.Disciplinas");
            DropForeignKey("dbo.ProfessorDisciplinas", "Professor_Id", "dbo.Pessoas");
            DropForeignKey("dbo.AlunoDisciplinas", "Disciplina_Id", "dbo.Disciplinas");
            DropForeignKey("dbo.AlunoDisciplinas", "Aluno_Id", "dbo.Pessoas");
            DropIndex("dbo.ProfessorDisciplinas", new[] { "Disciplina_Id" });
            DropIndex("dbo.ProfessorDisciplinas", new[] { "Professor_Id" });
            DropIndex("dbo.AlunoDisciplinas", new[] { "Disciplina_Id" });
            DropIndex("dbo.AlunoDisciplinas", new[] { "Aluno_Id" });
            DropTable("dbo.ProfessorDisciplinas");
            DropTable("dbo.AlunoDisciplinas");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Disciplinas");
        }
    }
}
