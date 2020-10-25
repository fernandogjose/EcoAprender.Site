using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Parentesco : Base
    {
        public string Descricao { get; set; }

        public virtual ICollection<AlunoPais> AlunosPais { get; set; }
    }
}
