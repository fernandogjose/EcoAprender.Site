namespace Domain.Entities.Email
{
    public class EmailEnviar
    {
        public string DestinoNome { get; set; }

        public string DestinoEmail { get; set; }

        public string RemetenteNome { get; set; }

        public string RemetenteEmail { get; set; }

        public string Assunto { get; set; }

        public string Body { get; set; }
    }
}
