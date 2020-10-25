using System;

namespace Domain.Entities
{
    public class RefeicaoStatus : Base
    {
        public string Descricao { get; set; }

        public int EscolaId { get; set; }
    }
}
