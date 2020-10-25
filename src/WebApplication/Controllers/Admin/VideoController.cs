using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Application;
using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Authorize;
using WebApplication.Utils;

namespace WebApplication.Controllers.Admin
{
    [CustomAuthorize]
    [RoutePrefix("portal-do-aluno/admin/video")]
    public class VideoController : Controller
    {
        private readonly IVideoAppService _videoAppService;
        private readonly IGrupoAppService _grupoAppService;

        public VideoController(IVideoAppService videoAppService, IGrupoAppService grupoAppService, ImageUtil imageUtil)
        {
            _videoAppService = videoAppService;
            _grupoAppService = grupoAppService;
        }

        [Route]
        public ActionResult Index()
        {
            var videos = _videoAppService.GetAll().OrderByDescending(x => x.Data).ToList();
            return View("~/Views/PortalDoAluno/Admin/Video/Index.cshtml", videos);
        }

        [Route("{id:int}")]
        public ActionResult VideoCadastrar(int id)
        {
            var video = new Video();
            if (id > 0)
            {
                video = _videoAppService.Get(id);
            }

            video.Grupos = _grupoAppService.GetAll().OrderBy(x => x.Descricao).ToList();

            return View("~/Views/PortalDoAluno/Admin/Video/Form.cshtml", video);
        }

        [Route("salvar")]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Salvar(Video video)
        {
            try
            {
                video.EscolaId = 1;
                _videoAppService.Save(video);
                return RedirectToAction("Index");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }

        [Route("excluir")]
        [HttpPost]
        public JsonResult Excluir(Video video)
        {
            try
            {
                _videoAppService.Remove(x => x.Id == video.Id);
                return Json("sucesso");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }
    }
}