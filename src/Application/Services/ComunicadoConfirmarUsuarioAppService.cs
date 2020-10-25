using Domain.Interfaces.Application;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class ComunicadoConfirmarUsuarioAppService : BaseAppService<ComunicadoConfirmarUsuario>, IComunicadoConfirmarUsuarioAppService
    {
        private readonly IComunicadoConfirmarUsuarioService _comunicadoConfirmarUsuarioService;

        public ComunicadoConfirmarUsuarioAppService(IComunicadoConfirmarUsuarioService comunicadoConfirmarUsuarioService)
            : base(comunicadoConfirmarUsuarioService)
        {
            _comunicadoConfirmarUsuarioService = comunicadoConfirmarUsuarioService;
        }
    }
}
