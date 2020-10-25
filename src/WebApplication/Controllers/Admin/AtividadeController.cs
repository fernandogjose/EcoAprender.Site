using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Application;
using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Authorize;
using WebApplication.Utils;
using WebApplication.ViewModel;

namespace WebApplication.Controllers.Admin
{
    [CustomAuthorize]
    [RoutePrefix("portal-do-aluno/admin/atividade")]
    public class AtividadeController : Controller
    {
        private readonly IAtividadeAppService _atividadeAppService;
        private readonly IGrupoAppService _grupoAppService;
        private readonly ImageUtil _imageUtil;

        public AtividadeController(IAtividadeAppService atividadeAppService, IGrupoAppService grupoAppService, ImageUtil imageUtil)
        {
            _atividadeAppService = atividadeAppService;
            _grupoAppService = grupoAppService;
            _imageUtil = imageUtil;
        }

        [Route("upload-file")]
        [HttpPost]
        public JsonResult UploadFile()
        {
            var atividadeId = (int)Session["atividadeId"];
            var uploadFileViewModel = new UploadFileViewModel();

            try
            {
                if (Request.Files.AllKeys.Any())
                {
                    var httpPostedFile = Request.Files[0];
                    if (httpPostedFile != null)
                    {
                        uploadFileViewModel.CaminhoDoArquivo = Server.MapPath(string.Format(@"/img/atividades/{0}", atividadeId));
                    }

                    _imageUtil.UploadFoto(httpPostedFile, uploadFileViewModel.CaminhoDoArquivo);

                    uploadFileViewModel.CaminhoDoArquivo = string.Format(@"/img/atividades/{0}/{1}", atividadeId, httpPostedFile.FileName.Replace(" ", "").Trim());
                    uploadFileViewModel.NomeDoArquivo = httpPostedFile.FileName.Replace(" ", "").Trim();
                    uploadFileViewModel.Id = atividadeId;
                }
            }
            catch (Exception ex)
            {
            }

            return Json(uploadFileViewModel, JsonRequestBehavior.AllowGet);
        }

        [Route]
        public ActionResult Index()
        {
            var atividades = _atividadeAppService.GetAll(x => x.Data.Year == 2017).OrderByDescending(x => x.Data).ToList();
            return View("~/Views/PortalDoAluno/Admin/Atividade/Index.cshtml", atividades);
        }

        [Route("{id:int}")]
        public ActionResult AtividadeCadastrar(int id)
        {
            var atividade = new Atividade();
            var path = Server.MapPath(string.Format(@"/img/atividades/{0}", id));

            if (id > 0)
            {
                atividade = _atividadeAppService.Get(id);
                atividade.Fotos = _imageUtil.ListFotoAtividade(path, atividade.Id);
            }
            else
            {
                _imageUtil.ExcluirDiretorioOuFotoAtividade(path, false);
            }

            atividade.Grupos = _grupoAppService.GetAll().OrderBy(x => x.Descricao).ToList();

            Session["atividadeId"] = atividade.Id;

            return View("~/Views/PortalDoAluno/Admin/Atividade/Form.cshtml", atividade);
        }

        [Route("salvar")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Salvar(Atividade atividade)
        {
            var isNew = atividade.Id == 0;

            try
            {
                atividade.EscolaId = 1;
                atividade.Id = _atividadeAppService.SalvarPorApp(atividade);

                if (isNew)
                {
                    var pathDe = Server.MapPath(string.Format(@"/img/atividades/{0}", 0));
                    var pathPara = Server.MapPath(string.Format(@"/img/atividades/{0}", atividade.Id));
                    _imageUtil.RenameFolder(pathDe, pathPara);
                }

                return RedirectToAction("Index");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }

        [Route("excluir")]
        [HttpPost]
        public JsonResult Excluir(Atividade atividade)
        {
            try
            {
                _atividadeAppService.Remove(x => x.Id == atividade.Id);

                var arquivo = Server.MapPath(string.Format(@"/img/atividades/{0}", atividade.Id));
                _imageUtil.ExcluirDiretorioOuFotoAtividade(arquivo, false);

                return Json("sucesso");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }

        [Route("excluir-foto")]
        [HttpPost]
        public JsonResult ExcluirFoto(Atividade atividade)
        {
            try
            {
                var arquivo = Server.MapPath(string.Format(@"/img/atividades/{0}/{1}", atividade.Id, atividade.Arquivo));
                _imageUtil.ExcluirDiretorioOuFotoAtividade(arquivo, true);
                return Json("foto removida com sucesso");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }

        [Route("selecionar-foto-capa")]
        [HttpPost]
        public JsonResult SelecionarFotoCapa(Atividade atividade)
        {
            try
            {
                _atividadeAppService.SelecionarFotoCapa(atividade);
                return Json("Foto capa selecionada com sucesso");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }

        [Route("selecionar-foto-resumo")]
        [HttpPost]
        public JsonResult SelecionarFotoResumo(Atividade atividade)
        {
            try
            {
                _atividadeAppService.SelecionarFotoResumo(atividade);
                return Json("Foto resumo selecionada com sucesso");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }
    }
}