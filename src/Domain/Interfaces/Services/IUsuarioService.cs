using Domain.Entities;
using System.Collections.Generic;
using System.IO;

namespace Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Usuario Login(string login, string senha);

        IList<string> ListarPushNotificationIdPorTurma(int escolaId, int grupoId);
    }
}
