using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using Domain.ViewModels;

namespace WebApi.Controllers
{
    [RoutePrefix("para-tipo")]
    public class ParaTipoController : ApiController
    {
        [HttpGet]
        [Route("listar")]
        public HttpResponseMessage Index()
        {
            var response = new List<ParaTipoViewModel>();
            response.Add(new ParaTipoViewModel
            {
                Id = "usuario",
                Descricao = "Usuário"
            });

            response.Add(new ParaTipoViewModel
            {
                Id = "grupo",
                Descricao = "Grupo"
            });

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
