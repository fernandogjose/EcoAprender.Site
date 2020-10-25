using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Data.Repositories
{
    public class ComunicadoRepository : BaseRepository<Comunicado>, IComunicadoRepository
    {
        public ComunicadoRepository()
            : base() { }
    }
}
