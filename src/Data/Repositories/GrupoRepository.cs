using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Data.Repositories
{
    public class GrupoRepository : BaseRepository<Grupo>, IGrupoRepository
    {
        public GrupoRepository()
            : base() { }
    }
}
