using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace WebApi.Controllers
{
    [RoutePrefix("medicamento")]
    public class MedicamentoController : ApiController
    {
        private readonly IMedicamentoService _medicamentoService;

        public MedicamentoController(IMedicamentoService medicamentoService)
        {
            _medicamentoService = medicamentoService;
        }

        [HttpGet]
        [Route("{alunoId:int}/{escolaId:int}")]
        public HttpResponseMessage Index(int alunoId, int escolaId)
        {
            var medicamentos = _medicamentoService.List(new Medicamento { AlunoId = alunoId, EscolaId = escolaId });
            return Request.CreateResponse(HttpStatusCode.OK, medicamentos);
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(Medicamento medicamento)
        {
            _medicamentoService.Add(medicamento);
            return Request.CreateResponse(HttpStatusCode.OK, "Adicionado com sucesso");
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(Medicamento medicamento)
        {
            _medicamentoService.Update(medicamento);
            return Request.CreateResponse(HttpStatusCode.OK, "Adicionado com sucesso");
        }

        [HttpPost]
        [Route("delete")]
        public HttpResponseMessage Delete(Medicamento medicamento)
        {
            _medicamentoService.Delete(medicamento);
            return Request.CreateResponse(HttpStatusCode.OK, "Adicionado com sucesso");
        }
    }
}
