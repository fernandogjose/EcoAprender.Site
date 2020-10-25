using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class EscolaAppService : BaseAppService<Escola>, IEscolaAppService
    {
        private readonly IEscolaService _escolaService;

        public EscolaAppService(IEscolaService escolaService)
            : base(escolaService)
        {
            _escolaService = escolaService;
        }
    }
}
