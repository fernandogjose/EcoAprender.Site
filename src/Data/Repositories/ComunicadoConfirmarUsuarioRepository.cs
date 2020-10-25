using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Data.Repositories
{
    public class ComunicadoConfirmarUsuarioRepository : BaseRepository<ComunicadoConfirmarUsuario>, IComunicadoConfirmarUsuarioRepository
    {
        public ComunicadoConfirmarUsuarioRepository()
            : base() { }
    }
}
