namespace Domain.Entities
{
    public class SugestaoResposta : Base
    {
        public string Descricao { get; set; }

        public int SugestaoId { get; set; }

        public virtual Sugestao Sugestao { get; set; }
    }
}
