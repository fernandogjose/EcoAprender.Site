using Domain.Entities;
using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class ChatViewModel : Base
    {
        public int De { get; set; }

        public int Para { get; set; }

        public int GrupoParaId { get; set; }

        public string ParaTipo { get; set; }

        public string Assunto { get; set; }

        public string Mensagem { get; set; }

        public UsuarioViewModel UsuarioDe { get; set; }

        public UsuarioViewModel UsuarioPara { get; set; }

        public GrupoViewModel GrupoPara { get; set; }

        public IEnumerable<ChatMensagemViewModel> ChatMensagens { get; set; }
    }
}