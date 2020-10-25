using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using Domain.Mappers;
using Domain.Entities;
using System.Web;
using System.IO;
using System;
using Domain.ViewModels;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [RoutePrefix("atividade")]
    public class AtividadeController : ApiController
    {
        private readonly IAtividadeAppService _atividadeAppService;

        public AtividadeController(IAtividadeAppService atividadeAppService)
        {
            _atividadeAppService = atividadeAppService;
        }

        [HttpGet]
        [Route("{pagina:int}/{escolaId:int}")]
        public HttpResponseMessage Index(int pagina, int escolaId)
        {
            pagina = pagina * 5;
            var atividades = _atividadeAppService.GetAll(x => x.EscolaId == escolaId).OrderByDescending(x => x.Data).Skip(pagina).Take(5).ToList();
            var response = AtividadeMapper.ObterViewModelPorModel(atividades);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("listar/{escolaId:int}")]
        public HttpResponseMessage Listar(int escolaId)
        {
            var atividades = _atividadeAppService.GetAll(x => x.EscolaId == escolaId).OrderByDescending(x => x.Data).ToList();
            var response = AtividadeMapper.ObterViewModelPorModel(atividades);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("salvar")]
        public HttpResponseMessage Salvar(Atividade atividade)
        {
            atividade.Id = _atividadeAppService.SalvarPorApp(atividade);
            var response = AtividadeMapper.ObterViewModelPorModel(atividade);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost, HttpGet]
        [Route("upload")]
        public HttpResponseMessage Upload()
        {
            try
            {
                var atividadeId = HttpContext.Current.Request.Form.Get("AtividadeId");
                if (string.IsNullOrEmpty(atividadeId)) return Request.CreateResponse(HttpStatusCode.NoContent, "Atividade Id é obrigatório");

                var file = HttpContext.Current.Request.Files["recFile"];
                if (file == null) return Request.CreateResponse(HttpStatusCode.NoContent, "Imagem não econtrada");

                var path = string.Format(@"C:\inetpub\ecoaprender.com.br\img\atividades\{0}\", atividadeId);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                file.SaveAs(path + file.FileName.Replace(" ", "-"));

                var imagem = string.Format("http://www.ecoaprender.com.br/img/atividades/{0}/{1}", atividadeId, file.FileName.Replace(" ", "-"));
                return Request.CreateResponse(HttpStatusCode.OK, imagem);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("remover-foto")]
        public HttpResponseMessage RemoverFoto(AtividadeViewModel atividadeViewModel)
        {
            var path = string.Format(@"C:\inetpub\ecoaprender.com.br\img\atividades\{0}", atividadeViewModel.Id);
            var arquivo = atividadeViewModel.Arquivo.Split('/');

            var file = string.Format(@"{0}\{1}", path, arquivo[arquivo.Length - 1]);

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            var fotos = new List<string>();
            if (Directory.Exists(path))
            {
                foreach (var foto in Directory.GetFiles(path))
                {
                    fotos.Add(string.Format("http://www.ecoaprender.com.br/img/atividades/{0}/{1}", atividadeViewModel.Id, Path.GetFileName(foto)));
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, fotos);
        }
    }
}
