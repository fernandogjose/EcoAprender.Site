using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository()
            : base() { }

        public Usuario Login(string login, string senha)
        {
            var usuario = Context.Usuario.FirstOrDefault(x => x.Login == login && x.Senha == senha);
            return usuario;
        }
    }
}
