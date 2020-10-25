using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using Domain.Mappers;
using Domain.Entities;

namespace WebApi.Controllers
{
    [RoutePrefix("comunicado")]
    public class ComunicadoController : ApiController
    {
        private readonly IComunicadoAppService _comunicadoAppService;

        public ComunicadoController(IComunicadoAppService comunicadoAppService)
        {
            _comunicadoAppService = comunicadoAppService;
        }

        [HttpGet]
        [Route("{pagina:int}/{escolaId:int}")]
        public HttpResponseMessage Index(int pagina, int escolaId)
        {
            pagina = pagina * 10;
            var comunicados = _comunicadoAppService.GetAll(x => x.EscolaId == escolaId).OrderByDescending(x => x.Data).Skip(pagina).Take(10).ToList();
            var response = ComunicadoMapper.ObterViewModelPorModel(comunicados);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("relatorio/{comunicadoId:int}")]
        public HttpResponseMessage Relatorio(int comunicadoId)
        {
            var response = _comunicadoAppService.Relatorio(new Comunicado { Id = comunicadoId });
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
