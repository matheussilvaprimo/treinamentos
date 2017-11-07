using System;
using System.Collections.Generic;

namespace TPCSampleEntityFramework
{
    public class Disciplina
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public long CapacidadeAlunos { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Professor> Professores { get; set; }
    }
}
