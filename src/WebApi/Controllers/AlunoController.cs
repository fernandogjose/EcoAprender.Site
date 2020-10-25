using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace WebApi.Controllers
{
    [RoutePrefix("aluno")]
    public class AlunoController : ApiController
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        [Route("{usuarioId:int}/{escolaId:int}")]
        public HttpResponseMessage Index(int usuarioId, int escolaId)
        {
            var alunos = _alunoService.List(new Aluno { UsuarioId = usuarioId, EscolaId = escolaId });
            return Request.CreateResponse(HttpStatusCode.OK, alunos);
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(Aluno aluno)
        {
            _alunoService.Add(aluno);
            return Request.CreateResponse(HttpStatusCode.OK, "Adicionado com sucesso");
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(Aluno aluno)
        {
            _alunoService.Update(aluno);
            return Request.CreateResponse(HttpStatusCode.OK, "Adicionado com sucesso");
        }

        [HttpPost]
        [Route("delete")]
        public HttpResponseMessage Delete(Aluno aluno)
        {
            _alunoService.Delete(aluno);
            return Request.CreateResponse(HttpStatusCode.OK, "Adicionado com sucesso");
        }
    }
}
