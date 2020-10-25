namespace Domain.Entities
{
    public class EmailEsqueciMinhaSenha
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int TokenForForgetPassword { get; set; }
    }
}
