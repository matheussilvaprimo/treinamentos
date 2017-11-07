using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TPHSampleEntityFramework6
{
    public class MyCustomDBInitializer : CreateDatabaseIfNotExists<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            AddNewDisciplines(context);
            base.Seed(context);
        }

        private void AddNewDisciplines(AppContext context)
        {
            var list = new List<Disciplina>
            {
                new Disciplina
                {
                    Id = Guid.NewGuid(),
                    Nome = "Matemática",
                    CapacidadeAlunos = 20
                },

                new Disciplina
                {
                    Id = Guid.NewGuid(),
                    Nome = "Português",
                    CapacidadeAlunos = 30
                },

                new Disciplina
                {
                    Id = Guid.NewGuid(),
                    Nome = "Física Quântica",
                    CapacidadeAlunos = 15
                },

                new Disciplina
                {
                    Id = Guid.NewGuid(),
                    Nome = "Química",
                    CapacidadeAlunos = 20
                }
            };

            context.Disciplinas.AddRange(list);
            context.SaveChanges();
        }
    }
}
