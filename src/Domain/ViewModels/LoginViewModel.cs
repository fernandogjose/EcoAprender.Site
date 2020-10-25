namespace Domain.ViewModels
{
    public class LoginViewModel
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string UsuarioNome { get; set; }

        public string Perfil { get; set; }

        public string PushNotificationAndroidRegistrationId { get; set; }

        public EscolaViewModel Escola { get; set; }
    }
}