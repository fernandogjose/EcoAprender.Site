using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Data.Repositories
{
    public class ComunicadoLeituraUsuarioRepository : BaseRepository<ComunicadoLeituraUsuario>, IComunicadoLeituraUsuarioRepository
    {
        public ComunicadoLeituraUsuarioRepository()
            : base() { }
    }
}
