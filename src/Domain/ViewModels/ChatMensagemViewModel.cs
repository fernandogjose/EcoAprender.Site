using Domain.Entities;

namespace Domain.ViewModels
{
    public class ChatMensagemViewModel : Base
    {
        public int De { get; set; }

        public string Mensagem { get; set; }

        public UsuarioViewModel UsuarioDe { get; set; }
    }
}
