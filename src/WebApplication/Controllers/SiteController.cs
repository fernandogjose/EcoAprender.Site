using Domain.Entities.Email;
using Domain.Exceptions;
using Domain.Interfaces.Application;
using Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Domain.Entities;
using System.IO;

namespace WebApplication.Controllers
{
    public class SiteController : Controller
    {
        private readonly IAtividadeAppService _atividadeAppService;
        private readonly IGrupoAppService _grupoAppService;
        private readonly IBlogAppService _blogAppService;
        private readonly IVideoAppService _videoAppService;
        private readonly IFaleConoscoService _faleConoscoServiceService;

        public SiteController(IAtividadeAppService atividadeAppService, IVideoAppService videoAppService, IFaleConoscoService faleConoscoServiceService, IBlogAppService blogAppService, IGrupoAppService grupoAppService)
        {
            _atividadeAppService = atividadeAppService;
            _videoAppService = videoAppService;
            _faleConoscoServiceService = faleConoscoServiceService;
            _blogAppService = blogAppService;
            _grupoAppService = grupoAppService;
        }

        [Route]
        public ActionResult Index()
        {
            var atividades = _atividadeAppService.GetAll().OrderByDescending(x => x.Data).ToList();
            var blogs = _blogAppService.GetAll(x => x.Data <= DateTime.Now).OrderByDescending(x => x.Data).Take(8).ToList();
            var videos = _videoAppService.GetAll().OrderByDescending(x => x.Data).Take(5).ToList();

            ViewBag.Atividades = atividades;
            ViewBag.Blogs = blogs;
            ViewBag.Videos = videos;

            return View();
        }

        [Route("sobre")]
        public ActionResult Sobre()
        {
            return View();
        }

        [Route("professor")]
        public ActionResult Professor()
        {
            return View();
        }

        [Route("fale-conosco")]
        public ActionResult FaleConosco()
        {
            return View(new FaleConosco());
        }

        [Route("instagram")]
        public ActionResult Instagram()
        {
            return View();
        }

        [Route("facebook")]
        public ActionResult Facebook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaleConoscoEnviar(FaleConosco faleConosco)
        {
            try
            {
                _faleConoscoServiceService.Enviar(faleConosco);

                faleConosco.Alerta = "sucesso";
                return View("FaleConosco", faleConosco);
            }
            catch (CommonException commonException)
            {
                faleConosco.Alerta = "erro";
                return View("FaleConosco", faleConosco);
            }
        }

        [Route("atividades/{grupoId:int?}")]
        public ActionResult Atividades(int grupoId = 0)
        {
            var grupos = _grupoAppService.GetAll().ToList();
            ViewBag.Grupos = grupos;

            var atividades = (grupoId == 0
                ? _atividadeAppService.GetAll(x => x.Data.Year == 2017).OrderByDescending(x => x.Data).ToList()
                : _atividadeAppService.GetAll(x => x.GrupoId == grupoId && x.Data.Year == 2017).OrderByDescending(x => x.Data).ToList());

            return View(atividades);
        }

        [Route("atividade/{link}")]
        public ActionResult Atividade(string link)
        {
            var atividade = _atividadeAppService.GetAll(x => x.Link.ToLower() == link.ToLower()).FirstOrDefault();
            return View(atividade);
        }

        [Route("blog/{link}")]
        public ActionResult Blog(string link)
        {
            var categorias = _blogAppService.GetAll().OrderBy(x => x.Categoria).GroupBy(x => x.Categoria).Select(x => x.Key).ToList();
            ViewBag.Categorias = categorias;

            var blogs = _blogAppService.GetAll(x => x.Data <= DateTime.Now).OrderByDescending(x => x.Data).Take(8).ToList();
            ViewBag.Blogs = blogs;

            var blog = _blogAppService.GetAll(x => x.Link == link).FirstOrDefault();
            return View(blog);
        }

        [Route("blog-por-categoria/{categoria}")]
        public ActionResult BlogPorCategoria(string categoria)
        {
            var categorias = _blogAppService.GetAll().OrderBy(x => x.Categoria).GroupBy(x => x.Categoria).Select(x => x.Key).ToList();
            ViewBag.Categorias = categorias;

            var blogs = _blogAppService.GetAll(x => x.Data <= DateTime.Now && (x.Categoria == categoria || categoria == "todas")).OrderByDescending(x => x.Data).ToList();
            return View(blogs);
        }

        [Route("blog-por-tag/{tag}")]
        public ActionResult BlogPorTag(string tag)
        {
            var categorias = _blogAppService.GetAll().OrderBy(x => x.Categoria).GroupBy(x => x.Categoria).Select(x => x.Key).ToList();
            ViewBag.Categorias = categorias;

            var blogs = _blogAppService.GetAll(x => x.Data <= DateTime.Now && x.Tag.Contains(tag)).OrderByDescending(x => x.Data).ToList();
            return View("BlogPorCategoria", blogs);
        }

        [Route("videos")]
        public ActionResult Videos(string tag)
        {
            var videos = _videoAppService.GetAll().OrderByDescending(x => x.Data).ToList();
            return View(videos);
        }

        [Route("fotos")]
        public ActionResult Fotos()
        {
            List<string> fotosNomes = new List<string>(0);
            string[] fotos = Directory.GetFiles(Server.MapPath("/img/fotos"));
            foreach (var foto in fotos)
            {
                var index = foto.IndexOf("img");
                fotosNomes.Add(foto.Substring(index));
            }

            return View(fotosNomes);
        }

        [Route("programa-bilingue")]
        public ActionResult ProgramaBilingue()
        {
            return View("ProgramaBilingue");
        }
    }
}