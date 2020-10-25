using System;

namespace Domain.Entities
{
    public class Leite : Base
    {
        public int Quantidade { get; set; }

        public int Temperatura { get; set; }

        public int AgendaId { get; set; }

        public DateTime Horario { get; set; }
    }
}
