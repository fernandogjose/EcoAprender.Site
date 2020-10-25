using System.Collections.Generic;

namespace Domain.Entities
{
    public class Escola : Base
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }

        public virtual ICollection<Calendario> Calendarios { get; set; }

        public virtual ICollection<Cardapio> Cardapios { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }

        public virtual ICollection<ChatMensagem> ChatMensagens { get; set; }

        public virtual ICollection<Comunicado> Comunicados { get; set; }

        public virtual ICollection<ComunicadoConfirmarUsuario> ComunicadoConfirmarUsuarios { get; set; }

        public virtual ICollection<ComunicadoLeituraUsuario> ComunicadoLeituraUsuarios { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }

        public virtual ICollection<GrupoUsuario> GrupoUsuarios { get; set; }

        public virtual ICollection<Perfil> Perfils { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }

        public virtual ICollection<Medicamento> Medicamentos { get; set; }
    }
}
