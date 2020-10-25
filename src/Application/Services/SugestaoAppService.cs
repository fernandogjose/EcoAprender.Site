using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class SugestaoAppService : BaseAppService<Sugestao>, ISugestaoAppService
    {
        private readonly ISugestaoService _sugestaoService;

        public SugestaoAppService(ISugestaoService sugestaoService)
            : base(sugestaoService)
        {
            _sugestaoService = sugestaoService;
        }
    }
}
