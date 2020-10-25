using System.Collections.Generic;

namespace Domain.Entities
{
    public class GrupoUsuario : Base
    {
        public int GrupoId { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Grupo Grupo { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }
    }
}
