using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class GrupoAppService : BaseAppService<Grupo>, IGrupoAppService
    {
        private readonly IGrupoService _grupoService;

        public GrupoAppService(IGrupoService grupoService)
            : base(grupoService)
        {
            _grupoService = grupoService;
        }
    }
}
