using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class SugestaoRespostaAppService : BaseAppService<SugestaoResposta>, ISugestaoRespostaAppService
    {
        private readonly ISugestaoRespostaService _sugestaoRespostaService;

        public SugestaoRespostaAppService(ISugestaoRespostaService sugestaoRespostaService)
            : base(sugestaoRespostaService)
        {
            _sugestaoRespostaService = sugestaoRespostaService;
        }
    }
}
