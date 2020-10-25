using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ComunicadoConfirmarUsuario : Base
    {
        public int UsuarioId { get; set; }

        public int ComunicadoId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Comunicado Comunicado { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }
    }
}
