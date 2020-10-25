using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Aluno : Base
    {
        public string Nome { get; set; }

        public int GrupoId { get; set; }

        public int EscolaId { get; set; }

        [NotMapped]
        public int UsuarioId { get; set; }

        public virtual Grupo Grupo { get; set; }        

        public virtual Escola Escola { get; set; }

        public virtual ICollection<AlunoPais> AlunosPais { get; set; }

        public virtual ICollection<Medicamento> Medicamentos { get; set; }
    }
}
