using System;
using System.Collections.Generic;

namespace TPHSampleEntityFramework6
{
    public class Professor : Pessoa
    {
        public DateTime DataContratacao { get; set; }
        public List<Disciplina> DisciplinasMinistrando { get; set; }

    }
}
