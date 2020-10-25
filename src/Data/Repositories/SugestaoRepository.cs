using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class SugestaoRepository : BaseRepository<Sugestao>, ISugestaoRepository
    {
        public SugestaoRepository()
            : base() { }
    }
}
