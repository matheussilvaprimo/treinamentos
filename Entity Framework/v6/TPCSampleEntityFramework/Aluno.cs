﻿using System;
using System.Collections.Generic;

namespace TPCSampleEntityFramework
{
    public class Aluno : Pessoa
    {
        public DateTime DataIngresso { get; set; }
        public long SemestreAtual { get; set; }
        public List<Disciplina> DisciplinasCursando { get; set; }
    }
}
