using Domain.Entities;
using System.Collections.Generic;
using System.IO;

namespace Domain.Interfaces.Application
{
    public interface IUsuarioAppService : IBaseAppService<Usuario>
    {
        Usuario Login(string login, string senha);

        void AtualizarToken(Usuario usuario);

        IList<string> ListarPushNotificationIdPorTurma(int escolaId, int grupoId);
    }
}
