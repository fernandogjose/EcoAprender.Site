using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;


namespace Data.Repositories
{
    public class EscolaRepository : BaseRepository<Escola>, IEscolaRepository
    {
        public EscolaRepository()
            : base() { }
    }
}
