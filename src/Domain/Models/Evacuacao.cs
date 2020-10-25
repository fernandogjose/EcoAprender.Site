using System;

namespace Domain.Entities
{
    public class Evacuacao : Base
    {
        public string Status { get; set; }

        public int AgendaId { get; set; }

        public DateTime Horario { get; set; }
    }
}
