using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Application;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Authorize;

namespace WebApplication.Controllers.Admin
{
    //[CustomAuthorize]
    [RoutePrefix("portal-do-aluno/admin/comunicado")]
    public class ComunicadoController : Controller
    {
        private readonly IComunicadoAppService _comunicadoAppService;

        public ComunicadoController(IComunicadoAppService comunicadoAppService)
        {
            _comunicadoAppService = comunicadoAppService;
        }

        [Route]
        public ActionResult Index()
        {
            var comunicados = _comunicadoAppService.GetAll().OrderByDescending(x => x.Data).ToList();
            return View("~/Views/PortalDoAluno/Admin/Comunicado/Index.cshtml", comunicados);
        }

        [Route("{id:int}")]
        public ActionResult ComunicadoCadastrar(int id)
        {
            var comunicado = new Comunicado();
            if (id > 0)
            {
                comunicado = _comunicadoAppService.Get(id);
            }

            return View("~/Views/PortalDoAluno/Admin/Comunicado/Form.cshtml", comunicado);
        }

        [Route("salvar")]
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Salvar(Comunicado comunicado)
        {
            try
            {
                comunicado.Descricao = comunicado.Descricao
                                                        .Replace("<!DOCTYPE html>", "")
                                                        .Replace("<html>", "")
                                                        .Replace("<head>", "")
                                                        .Replace("</head>", "")
                                                        .Replace("<body>", "")
                                                        .Replace("</body>", "")
                                                        .Replace("</html>", "");
                comunicado.EscolaId = 1;
                _comunicadoAppService.Save(comunicado);
                return Json("sucesso");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }

        [Route("excluir")]
        [HttpPost]
        public JsonResult Excluir(Comunicado comunicado)
        {
            try
            {
                _comunicadoAppService.Remove(comunicado);
                return Json("sucesso");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }
    }
}