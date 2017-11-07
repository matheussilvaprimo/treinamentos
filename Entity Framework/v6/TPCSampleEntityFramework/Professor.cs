using System;
using System.Collections.Generic;

namespace TPCSampleEntityFramework
{
    public class Professor : Pessoa
    {
        public DateTime DataContratacao { get; set; }
        public List<Disciplina> DisciplinasMinistrando { get; set; }
    }
}
