using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using Domain.Entities;

namespace WebApi.Controllers
{
    [RoutePrefix("sugestao")]
    public class SugestaoController : ApiController
    {
        private readonly ISugestaoAppService _sugestaoAppService;
        private readonly ISugestaoRespostaAppService _sugestaoRespostaAppService;

        public SugestaoController(ISugestaoAppService sugestaoAppService, ISugestaoRespostaAppService sugestaoRespostaAppService)
        {
            _sugestaoAppService = sugestaoAppService;
            _sugestaoRespostaAppService = sugestaoRespostaAppService;
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage Index(Sugestao request)
        {
            request.Pagina = request.Pagina * 5;
            var sugestoes = _sugestaoAppService.GetAll(x => x.Email == request.Email).OrderByDescending(x => x.DataInclusao).Skip(request.Pagina).Take(5).ToList();
            var response = Request.CreateResponse(HttpStatusCode.OK, sugestoes);
            return response;
        }

        [HttpPost]
        [Route("adicionar")]
        public HttpResponseMessage Adicionar(Sugestao request)
        {
            _sugestaoAppService.Add(request);
            var response = Request.CreateResponse(HttpStatusCode.OK, request);
            return response;
        }

        [HttpPost]
        [Route("responder")]
        public HttpResponseMessage Responder(SugestaoResposta request)
        {
            _sugestaoRespostaAppService.Add(request);
            var response = Request.CreateResponse(HttpStatusCode.OK, request);
            return response;
        }
    }
}
