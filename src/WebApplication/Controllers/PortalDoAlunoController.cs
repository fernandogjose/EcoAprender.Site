using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Authorize;

namespace WebApplication.Controllers
{
    [CustomAuthorize]
    [RoutePrefix("portal-do-aluno")]
    public class PortalDoAlunoController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IComunicadoAppService _comunicadoAppService;

        public PortalDoAlunoController(IUsuarioAppService usuarioAppService, IComunicadoAppService comunicadoAppService)
        {
            _usuarioAppService = usuarioAppService;
            _comunicadoAppService = comunicadoAppService;
        }

        [AllowAnonymous]
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("login/{login}/{senha}")]
        [HttpGet]
        public JsonResult Login(string login, string senha)
        {
            try
            {
                var usuario = _usuarioAppService.Login(login, senha);

                Session.Add("UsuarioId", usuario.Id);
                Session.Add("UsuarioLogin", usuario.Login);
                Session.Add("UsuarioNome", usuario.Nome);
                Session.Add("UsuarioPerfilId", usuario.PerfilId);
                Session.Add("UsuarioFoto", usuario.Foto);

                //--- OAuth
                FormsAuthentication.SetAuthCookie(usuario.Login, true);

                return Json("sucesso", JsonRequestBehavior.AllowGet);
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("painel")]
        public ActionResult Painel()
        {
            var comunicados = _comunicadoAppService.GetAll().OrderByDescending(x => x.Id).Take(8).ToList();
            ViewBag.Comunicados = comunicados;

            ViewBag.UsuarioNome = Session["UsuarioNome"] ?? "";
            ViewBag.UsuarioFoto = Session["UsuarioFoto"] != null && !string.IsNullOrEmpty(Session["UsuarioFoto"].ToString()) ? Session["UsuarioFoto"] : "logo-eco-aprender.jpg";

            return View();
        }

        [Route("sair")]
        public ActionResult Sair()
        {
            //--- Clears out Session
            Session.Clear();
            Session.Abandon();

            //--- Signs out of WebSecurity and FormsAuthentication
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "");
        }

        [Route("usuario")]
        public ActionResult Usuario()
        {
            var usuarios = _usuarioAppService.GetAll(x => x.EscolaId == 1).OrderBy(x => x.Nome).ToList();
            ViewBag.Usuarios = usuarios;

            return View(usuarios);
        }

        [Route("usuario/{login}")]
        public ActionResult UsuarioCadastrar(string login)
        {
            var usuario = new Usuario();
            if (login.ToLower() != "novo")
            {
                usuario = _usuarioAppService.GetAll(x => x.Login == login).FirstOrDefault();
                usuario.UsuarioNome = Session["UsuarioNome"].ToString();
            }

            return View(usuario);
        }

        [Route("usuario-salvar")]
        [HttpPost]
        public JsonResult UsuarioSalvar(Usuario usuario)
        {
            try
            {
                usuario.EscolaId = 1;
                _usuarioAppService.Save(usuario);
                return Json("sucesso");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }

        [Route("usuario-excluir")]
        [HttpPost]
        public JsonResult UsuarioExcluir(Usuario usuario)
        {
            try
            {
                _usuarioAppService.Remove(x => x.Id == usuario.Id);
                return Json("sucesso");
            }
            catch (CommonException commonException)
            {
                return Json(commonException.Error);
            }
        }
    }
}