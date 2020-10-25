using System;

namespace Domain.Entities
{
    public class RefeicaoAlimento : Base
    {
        public string Descricao { get; set; }

        public int EscolaId { get; set; }
    }
}
