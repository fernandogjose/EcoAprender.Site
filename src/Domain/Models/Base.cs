using System;

namespace Domain.Entities
{
    public class Base
    {
        public Base()
        {
            DataInclusao = DateTime.Now;
            DataAlteracao = DateTime.Now;
            UsuarioNome = "sistema";
        }

        public int Id { get; set; }

        public string UsuarioNome { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}

