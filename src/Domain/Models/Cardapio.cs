namespace Domain.Entities
{
    public class Cardapio : Base
    {
        public string Grupo { get; set; }

        public string Arquivo { get; set; }

        public int EscolaId { get; set; }

        public virtual Escola Escola { get; set; }
    }
}
