using System;

namespace TPCSampleEntityFramework
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public long Cpf { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Endereco { get; set; }
        public long Matricula { get; set; }
    }
}
