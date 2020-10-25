using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Sugestao : Base
    {
        public Sugestao()
        {
            Status = "enviado";
        }

        [NotMapped]
        public int Pagina { get; set; }

        public string Nome { get; set; }

        public string  Email { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Status { get; set; }

        public virtual ICollection<SugestaoResposta> SugestaoRespostas { get; set; }
    }
}
