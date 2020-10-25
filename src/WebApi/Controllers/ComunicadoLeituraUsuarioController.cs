using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using Domain.Entities;

namespace WebApi.Controllers
{
    [RoutePrefix("comunicado-leitura-usuario")]
    public class ComunicadoLeituraUsuarioController : ApiController
    {
        private readonly IComunicadoLeituraUsuarioAppService _comunicadoLeituraUsuarioAppService;

        public ComunicadoLeituraUsuarioController(IComunicadoLeituraUsuarioAppService comunicadoLeituraUsuarioAppService)
        {
            _comunicadoLeituraUsuarioAppService = comunicadoLeituraUsuarioAppService;
        }

        [HttpPost]
        [Route("salvar")]
        public HttpResponseMessage Salvar(ComunicadoLeituraUsuario request)
        {
            _comunicadoLeituraUsuarioAppService.Save(request);
            return Request.CreateResponse(HttpStatusCode.OK, "leitura adicionada com sucesso");
        }
    }
}
