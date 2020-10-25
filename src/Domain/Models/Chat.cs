using System.Collections.Generic;

namespace Domain.Entities
{
    public class Chat : Base
    {
        public int De { get; set; }

        public int? Para { get; set; }

        public int? GrupoParaId { get; set; }

        public string ParaTipo { get; set; }

        public string Assunto { get; set; }

        public string Mensagem { get; set; }

        public virtual Usuario UsuarioDe { get; set; }

        public virtual Usuario UsuarioPara { get; set; }

        public virtual Grupo GrupoPara { get; set; }

        public virtual ICollection<ChatMensagem> ChatMensagens { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }
    }
}
