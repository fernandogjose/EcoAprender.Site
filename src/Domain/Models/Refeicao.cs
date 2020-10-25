using System;

namespace Domain.Entities
{
    public class Refeicao : Base
    {
        public int RefeicaoTipoId { get; set; }

        public int RefeicaoAlimentoId { get; set; }

        public int RefeicaoStatusId { get; set; }

        public int AgendaId { get; set; }

        public DateTime Horario { get; set; }

        public string Observacao { get; set; }
    }
}
