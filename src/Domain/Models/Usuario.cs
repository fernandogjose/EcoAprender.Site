using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Usuario : Base
    {
        public Usuario()
        {
            DataDeAniversario = DateTime.Now;
            PerfilId = 2;
        }

        public string PushNotificationAndroidRegistrationId { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public string TelefoneResidencial { get; set; }

        public string TelefoneCelular { get; set; }

        public string Foto { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string NomeNoBoleto { get; set; }

        public int Acesso { get; set; }

        public int PerfilId { get; set; }

        public DateTime DataDeAniversario { get; set; }

        public virtual Perfil Perfil { get; set; }

        public virtual ICollection<Chat> ChatsDe { get; set; }

        public virtual ICollection<Chat> ChatsPara { get; set; }

        public virtual ICollection<ChatMensagem> ChatMensagens { get; set; }

        public virtual ICollection<GrupoUsuario> GrupoUsuarios { get; set; }

        public virtual ICollection<ComunicadoConfirmarUsuario> ComunicadoConfirmarUsuarios { get; set; }

        public virtual ICollection<ComunicadoLeituraUsuario> ComunicadoLeituraUsuarios { get; set; }

        public virtual ICollection<AlunoPais> AlunosPais { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }
    }
}
