using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Calendario : Base
    {
        public DateTime Data { get; set; }

        public string Evento { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }
    }
}
