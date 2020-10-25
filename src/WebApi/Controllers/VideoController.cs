using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Interfaces.Application;
using Domain.Mappers;

namespace WebApi.Controllers
{
    [RoutePrefix("video")]
    public class VideoController : ApiController
    {
        private readonly IVideoAppService _videoAppService;

        public VideoController(IVideoAppService videoAppService)
        {
            _videoAppService = videoAppService;
        }

        [HttpGet]
        [Route("{pagina:int}/{escolaId:int}")]
        public HttpResponseMessage Index(int pagina, int escolaId)
        {
            pagina = pagina * 10;
            var videos = _videoAppService.GetAll(x => x.EscolaId == escolaId).OrderByDescending(x => x.Data).Skip(pagina).Take(10).ToList();
            var response = VideoMapper.ObterViewModelPorModel(videos) ;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
