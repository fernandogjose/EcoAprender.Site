using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using Domain.Entities;

namespace WebApi.Controllers
{
    [RoutePrefix("comunicado-confirmar-usuario")]
    public class ComunicadoConfirmarUsuarioController : ApiController
    {
        private readonly IComunicadoConfirmarUsuarioAppService _comunicadoConfirmarUsuarioAppService;

        public ComunicadoConfirmarUsuarioController(IComunicadoConfirmarUsuarioAppService comunicadoConfirmarUsuarioAppService)
        {
            _comunicadoConfirmarUsuarioAppService = comunicadoConfirmarUsuarioAppService;
        }

        [HttpPost]
        [Route("confirmar")]
        public HttpResponseMessage Confirmar(ComunicadoConfirmarUsuario request)
        {
            _comunicadoConfirmarUsuarioAppService.Save(request);
            return Request.CreateResponse(HttpStatusCode.OK, "confirmação realizada com sucesso");
        }
    }
}
