using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Application.Services
{
    public class UsuarioAppService : BaseAppService<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Usuario Login(string login, string senha)
        {
            return _usuarioService.Login(login, senha);
        }

        public void AtualizarToken(Usuario usuario)
        {
            var usuarioAux = _usuarioService.Get(usuario.Id);
            usuarioAux.PushNotificationAndroidRegistrationId = usuario.PushNotificationAndroidRegistrationId;
            _usuarioService.Update(usuarioAux);
        }

        public IList<string> ListarPushNotificationIdPorTurma(int escolaId, int grupoId)
        {
            return _usuarioService.ListarPushNotificationIdPorTurma(escolaId, grupoId);
        }
    }
}
