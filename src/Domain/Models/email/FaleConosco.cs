using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Email
{
    public class FaleConosco : Base
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Assunto { get; set; }

        public string Mensagem { get; set; }

        [NotMapped]
        public string Alerta { get; set; }
    }
}
