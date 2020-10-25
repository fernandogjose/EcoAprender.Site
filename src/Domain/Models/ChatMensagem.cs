using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ChatMensagem : Base
    {
        public int ChatId { get; set; }

        public int De { get; set; }

        public string Mensagem { get; set; }

        public virtual Chat Chat { get; set; }

        public virtual Usuario UsuarioDe { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }
    }
}
