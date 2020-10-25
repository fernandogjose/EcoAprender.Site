using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using Domain.Mappers;

namespace WebApi.Controllers
{
    [RoutePrefix("grupo")]
    public class GrupoController : ApiController
    {
        private readonly IGrupoAppService _grupoAppService;

        public GrupoController(IGrupoAppService grupoAppService)
        {
            _grupoAppService = grupoAppService;
        }

        [HttpGet]
        [Route("listar/{escolaId:int}")]
        public HttpResponseMessage Listar(int escolaId)
        {
            var grupos = _grupoAppService.GetAll(x => x.EscolaId == escolaId).OrderBy(x => x.Descricao).ToList();
            var response = GrupoMapper.ObterViewModelsPorModels(grupos);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
