using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Data.Repositories
{
    public class SugestaoRespostaRepository : BaseRepository<SugestaoResposta>, ISugestaoRespostaRepository
    {
        public SugestaoRespostaRepository()
            : base() { }
    }
}
