using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class GrupoService : BaseService<Grupo>, IGrupoService
    {
        private readonly IGrupoRepository _grupoRepository;
        public GrupoService(IGrupoRepository grupoRepository)
            : base(grupoRepository)
        {
            _grupoRepository = grupoRepository;
        }
    }
}
