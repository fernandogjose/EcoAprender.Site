using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AlunoPais : Base
    {
        public int AlunoId { get; set; }

        public int UsuarioId { get; set; }

        public int ParentescoId { get; set; }

        public virtual Aluno Aluno { get; set; }
        
        public virtual Usuario Usuario { get; set; }

        public virtual Parentesco Parentesco { get; set; }
    }
}
