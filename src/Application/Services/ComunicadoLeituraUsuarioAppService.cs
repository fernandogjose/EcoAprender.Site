using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class ComunicadoLeituraUsuarioAppService : BaseAppService<ComunicadoLeituraUsuario>, IComunicadoLeituraUsuarioAppService
    {
        private readonly IComunicadoLeituraUsuarioService _comunicadoLeituraUsuarioService;

        public ComunicadoLeituraUsuarioAppService(IComunicadoLeituraUsuarioService comunicadoLeituraUsuarioService)
            : base(comunicadoLeituraUsuarioService)
        {
            _comunicadoLeituraUsuarioService = comunicadoLeituraUsuarioService;
        }
    }
}
